using System;
using static System.Console;
using static System.Math;

public class main{

static double d = 1e-10;
static double eps=0;

public static double erf(double z){
	Func<double, double> f=x =>Exp(-x*x);
	Func<double, double> F=t => f(z+(1-t)/t)/t/t;
	if(z<0){return (-1*erf(-z));}
	if(0 <= z | z<=1){return (2/Sqrt(PI)*matlib.integrate(f,0,z, d=d, eps=eps));}
	if(z>1){ return (1-2/Sqrt(PI)*matlib.integrate(F, 0,1,d=d,eps=eps));}
	else return 0.0;
	}
public static void Main(){
	for(double z=-3; z<=3; z+=1.0/8)
		Console.WriteLine($"{z} {erf(z)}");

WriteLine("\n");
        WriteLine("-2   -0.995322265");
        WriteLine("-1   -0.842700793");
        WriteLine("-0.5 -0.520499878");
        WriteLine("-0.2 -0.222702589");
        WriteLine(" 0.2  0.222702589");
        WriteLine(" 0.5  0.520499878");
        WriteLine(" 1    0.842700793");
        WriteLine(" 2    0.995322265");

}//Main
}//main


