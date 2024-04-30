using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;


public class ODE{
public static (vector, vector) rkstep12(
		Func<double, vector, vector> f,
		double x,
		vector y,
		double h
		)
{
	vector k0 = f(x,y);
	vector k1 = f(x+h/2, y+k0*(h/2));
	vector yh = y+k1*h;
	vector dy = (k1-k0)*h;
	return (yh,dy);
}
public static (genlist<double>, genlist<vector>) driver(
		Func<double, vector, vector> F,
		(double, double) interval,
		vector ystart,
		double h = 0.1,
		double acc = 0.01,
		double eps = 0.01
		)
{
	var (a,b) = interval;double x = a;vector y = ystart.copy();
	var xlist = new genlist<double>(); xlist.add(x);
	var ylist = new genlist<vector>(); ylist.add(y);
	do{
		if (x>=b) return (xlist, ylist);
		if (x+h>b) h=b-x;
		var (yh, dy) = rkstep12(F,x,y,h);
		double tol = (acc + eps*yh.norm())*Sqrt(h/(b-a));
		double err = dy.norm();
		if(err<=tol){
			x+=h; y=yh;
			xlist.add(x);
			ylist.add(y);
			}
		h *= Min( Pow(tol/err, 0.25)*0.95, 2);
	}while(true);
}
}		
