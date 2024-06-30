using System;
using static System.Console;
using System.Collections.Generic;
using static System.Math;
static class main{
	static void Main(){
		//part A
		double[] x = new double[30];
		double[] y = new double[30];
		double[] ix = new double[30];
		double[] iy = new double[30];
		for(int i = 0; i<x.Length; i++){
			x[i] = i/(2*PI);
			y[i] = Cos(x[i]);
			ix[i] = i/(2*PI);
			iy[i] = Sin(x[i]);
			WriteLine($"{x[i]} {y[i]} {ix[i]} {iy[i]}");
		}
		WriteLine("\n");

		//linear spline
		for(double j=x[0]; j<x[29]; j+=1.0/32){
			double si = spline.linterp(x,y,j);
			WriteLine($"{j} {si}");
			}

		//linear spline integral
		WriteLine("\n");
		for(double j=x[0]; j<x[29]; j+=1.0/32){
			double s_integ = spline.linterpInte(x,y,j);
			WriteLine($"{j} {s_integ}");
			}

		// Part B below
		WriteLine("\n");
		for(int i = 0; i<ix.Length; i++){
			WriteLine($"{ix[i]} {iy[i]} {y[i]} {1-y[i]}");
			}//x, Sin(x), (d/dx)Sin(x)=Cos(x), Sin(x)dx[0,x] = 1-Cos(x) 

		WriteLine($"\n");
		var myqspline = new qspline(ix,iy);
		for(double j = x[0]; j<x[29]; j+=1.0/32){
			double fz = myqspline.evaluate(j);
			WriteLine($"{j} {fz}");
		}
		WriteLine($"\n");
		for(double j = x[0]; j<x[29]; j+=1.0/32){
			double dfz = myqspline.derivative(j);
			WriteLine($"{j} {dfz}");
		}

		WriteLine($"\n");
		for(double j = x[0]; j<x[29]; j+=1.0/32){
			double Fz = myqspline.integral(j);
			WriteLine($"{j} {Fz}");
		}
}
}


			
			
			

			

