using System;
using static System.Console;
using static System.Math;
static class main{
	static void Main(){
		vector t = new vector("1, 2, 3, 4, 6, 9, 10, 13, 15");
		vector y = new vector("117, 100, 88, 72, 53, 29.5, 25.2, 15.2, 11.1");
		vector dy = new vector("6,5,4,4,4,3,3,2,2");
		vector lny = new vector(y.size);
		vector dlny = new vector(dy.size);
		for(int i=0; i<y.size; i++){
			lny[i] = Math.Log(y[i]);
			dlny[i] = dy[i]/y[i];
		}
		Func<double,double>[] fs = {x=>1,x=>-x};
		(vector c, matrix sigma) = fit.lsfit(fs,t,lny,dlny);
		vector dc = new vector(c.size);
		for(int i=0; i<dc.size; i++)dc[i] = Sqrt(sigma[i,i]);
		System.Func<double,double> fy = z => Exp(c[0])*Exp(-c[1]*z);
		System.Func<double, double> dfyp = z=> Exp(c[0]+dc[0])*Exp((-c[1]-dc[1])*z);
		System.Func<double, double> dfym = z=> Exp(c[0]-dc[0])*Exp((-c[1]+dc[1])*z);
		for(int i=0; i<t.size; i++)System.Console.Out.Write($"{t[i]} {fy(t[i])} {y[i]} {dy[i]} {dfyp(t[i])} {dfym(t[i])}\n");
		WriteLine($"\n");
		double tau = Log(2)/c[1];
		double dtau = tau*Sqrt((dc[1]/c[1])*(dc[1]/(c[1])));
		WriteLine($"half life for ThX from fit: {tau}+- {dtau} days");
		WriteLine($"half life for ThX, moderne value: 3.66 days");
	}}
