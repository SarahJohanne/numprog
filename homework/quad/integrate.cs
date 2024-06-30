using System;
using static System.Console;
using static System.Double;
using static System.Math;
public static partial class matlib{

public static double integrate (Func<double, double> f, double a, double b, double d=0.001, double eps=0.001, double f2=NaN, double f3=NaN){
	double h = b-a;
	if(IsNaN(f2)){
		f2 = f(a+2*h/6);
		f3 = f(a+4*h/6);
	}
	double f1 = f(a+h/6), f4=f(a+5*h/6);
	double Q = (2*f1+f2+f3+2*f4)/6*(b-a);
	double q = (f1+f2+f3+f4)/4*(b-a);
	double err = Abs(Q-q);
	if (err <= d+eps*Abs(Q)) return Q;
	else return integrate(f,a, (a+b)/2, d/Sqrt(2), eps, f1, f2)+integrate(f,(a+b)/2, b, d/Sqrt(2), eps, f3, f4);
}
//part B below
public static double ccintegrate (Func<double, double> f, double a, double b, double d=0.001, double eps=0.001){
	Func<double, double> fcc = t=> f((a+b)/2+(b-a)/2*Cos(t))*Sin(t)*(b-a)/2;
	return integrate(fcc,0,PI,d=d,eps=eps);
}
}

