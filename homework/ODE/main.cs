using System;
using static System.Console;
using static System.Math;


public static class main{
	public static void Main(){
		Func<double, vector, vector> tfunc = delegate(double x, vector y){
			vector dy = new vector(2);
			dy[0] = y[1];
			dy[1] = -y[0];
			return dy;
		};
		double x0 = 0; double end = 10; vector ystart = new vector(PI-0.1,0.0); 

		double b = 0.25;
		double c = 5.0;
		Func<double, vector, vector> fricfunc = delegate(double t, vector w){
			vector dw = new vector(2);
			dw[0] = w[1];
			dw[1] = -b*w[1]-c*Sin(w[0]);
			return dw;
		};

		var (xs, us) = ODE.driver(tfunc, ( x0,end),ystart);
		var (ts,thetas) = ODE.driver(fricfunc, (x0,end), ystart); 
		for(int i = 0; i<xs.size; i++)Out.WriteLine($"{xs[i]} {us[i][0]}");
		WriteLine($"\n");
		for(int i = 0; i<ts.size; i++)Out.WriteLine($"{ts[i]} {thetas[i][0]} {thetas[i][1]}");

// part b below
		double epsi = 0;
		vector init_i = new vector (1.0, 0.0);
		Func<double, vector, vector> relfunc = delegate(double phi, vector yu){
			vector dyu = new vector(2);
			dyu[0] = yu[1];
			dyu[1] = 1+epsi*yu[0]*yu[0]-yu[0];
			return dyu;
		};
		double u0 = 1; double du0 = 0;
		Func<double, vector> cirkelfunc = ODE.make_ode_ivp_interpolant(relfunc, (0,10), init_i);
		Out.WriteLine($"\n");
		for(double phi = 0; phi<1; phi+=1/10)Out.WriteLine($"{phi} {cirkelfunc(phi)[0]}");
		

}}
