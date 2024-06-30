using System;
using static System.Console;
using static System.Math;
static class main{
	static void Main(){

		vector t = new vector("1, 2, 3, 4, 6, 9, 10, 13, 15"); //time in days
		vector y = new vector("117, 100, 88, 72, 53, 29.5, 25.2, 15.2, 11.1"); //Activity (arb. u)
		vector dy = new vector("6,5,4,4,4,3,3,2,2"); //error on activity
		vector lny = new vector(y.size);
		vector dlny = new vector(dy.size); 
		
		for(int i=0; i<y.size; i++){
			lny[i] = Log(y[i]);
			dlny[i] = dy[i]/y[i];
		}
		Func<double,double>[] fs = {x=>1,x=>-x}; //decay function, when ln has been taken.
		(vector c, matrix sigma) = fit.lsfit(fs,t,lny,dlny);
		vector dc = new vector(c.size);
		for(int i=0; i<dc.size; i++)dc[i] = Sqrt(sigma[i,i]);
		System.Func<double,double> fy = z => Exp(c[0])*Exp(-c[1]*z);
		System.Func<double, double> dfyp = z=> Exp(c[0]+dc[0])*Exp((-c[1]-dc[1])*z);
		System.Func<double, double> dfym = z=> Exp(c[0]-dc[0])*Exp((-c[1]+dc[1])*z);
		for(int i=0; i<t.size; i++)WriteLine($"{t[i]} {fy(t[i])} {y[i]} {dy[i]} {dfyp(t[i])} {dfym(t[i])}");
		WriteLine($"\n");
		double tau = Log(2)/c[1];
		double dtau = tau*Sqrt((dc[1]/c[1])*(dc[1]/(c[1])));
		WriteLine($"--------------Task A----------------");
		WriteLine($"See plot.a.svg for plot of data and fit");
		WriteLine($"Half life for ThX from fit: {tau:f2} days");
		WriteLine($"Half life for ThX, modern value: 3.66 days");
		WriteLine($"--------------Task B----------------");
		WriteLine($"Half life for ThX from fit with uncertainties: {tau:f2}+- {dtau:f4} days");
		WriteLine($"Half life for ThX, modern value: 3.66 days");
		WriteLine($"The two values do not agree within the estimated uncertainty");
		WriteLine($"--------------Task C----------------");
		WriteLine($"See plot.c.svg for plot with changes in fit coefficients");
	}}
