using System;
using static System.Console;
using System.Collections.Generic;
using static System.Math;
static class main{
	static void Main(){
		double[] x = {0,1,2,3,4,5,6,7,8,9};
		double[] y = new double[10];
		for(int i = 0; i<x.Length; i++){
			y[i] = Cos(x[i]);
		}
		List<double> js = new List<double>();
		List<double> s = new List<double>();
		List<double> S = new List<double>();
		for(double j=x[0]; j<x[9]; j+=1.0/32){
			double si = spline.linterp(x,y,j);
			s.Add(si);
			js.Add(j);
			double s_integ = spline.linterpInte(x,y,j);
			S.Add(s_integ);
	}
		double[] S_test = new double[js.Count];
		double[] ds_test = new double[js.Count];
		double m = 2.3;
		var myqspline = new spline.qspline(x,y);
		List<double> qs = new List<double>();
		List<double> qds = new List<double>();
		List<double> qis = new List<double>();
		for(double j=x[0]; j<x[9]; j+=1.0/32){
			double qsj = myqspline.evaluate(j);
			double qdsj = myqspline.derivative(j);
			double qisj = myqspline.integral(j);
			qs.Add(qsj);
			qds.Add(qdsj);
			qis.Add(qisj);
		}
		for(int i=0; i<js.Count; i++){
		WriteLine($"{js[i]} {s[i]} {S[i]}");}
		WriteLine($"\n");
		for(int i=0; i<x.Length; i++){
		S_test[i] = Sin(x[i]);
		ds_test[i] = -Sin(x[i]);
		WriteLine($"{x[i]} {y[i]} {S_test[i]} {ds_test[i]}");}
		WriteLine($"\n");
		for(int i=0; i<js.Count; i++)WriteLine($"{js[i]} {qs[i]} {qds[i]} {qis[i]}"); 
}
}


			
			
			

			

