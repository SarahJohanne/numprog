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
		for(int i = 0; i<xs.size; i++)WriteLine($"{xs[i]} {us[i][0]}");
		WriteLine($"\n");
		for(int i = 0; i<ts.size; i++)WriteLine($"{ts[i]} {thetas[i][0]} {thetas[i][1]}");

// part b below
		double eps_i = 0.0;
		vector init_i = new vector (1, 0);
		Func<double, vector, vector> Newtfunc = delegate(double phi, vector yu){
			return new vector(yu[1],1+eps_i*yu[0]*yu[0]-yu[0]);
		};
		vector init_ii = new vector(1,-0.55);
		double eps_iii = 0.01;
		vector init_iii = new vector (1,-0.5);
		Func<double, vector, vector> relfunc = delegate(double phi, vector yu){
			return new vector(yu[1],1+eps_iii*yu[0]*yu[0]-yu[0]);
		};

		Func<double, vector> cirkelfunc = ODE.make_ode_ivp_interpolant(Newtfunc, (0,20), init_i);
		Func<double, vector> elipsoidfunc = ODE.make_ode_ivp_interpolant(Newtfunc, (0,10), init_ii);
		Func<double, vector> planetfunc = ODE.make_ode_ivp_interpolant(relfunc, (0,600), init_iii);
		
		Out.WriteLine($"\n");
		for(double phi = 0.0; phi<20; phi+=1.0/8){
			double u = cirkelfunc(phi)[0];
			WriteLine($"{(1/u)*Cos(phi)} {(1/u)*Sin(phi)}");
			}
		Out.WriteLine($"\n");
		for(double phi = 0.0; phi<10; phi+=1.0/8){
			double u = elipsoidfunc(phi)[0];
			WriteLine($"{(1/u)*Cos(phi)} {(1/u)*Sin(phi)}");
			}
		Out.WriteLine($"\n");
		for(double phi = 0.0; phi<600; phi+=1.0/16){
			double u = planetfunc(phi)[0];
			WriteLine($"{(1/u)*Cos(phi)} {(1/u)*Sin(phi)}");
			}
		

}}
