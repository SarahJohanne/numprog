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

}}
