using System;
using static System.Console;
using static System.Math;

public class spline{
	public static int binsearch(double[] x, double z){
		if( z<x[0] || z>x[x.Length-1] ) throw new Exception("binsearch: bad z");
		int i=0, j=x.Length-1;
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>x[mid])i=mid;
			else j=mid;
		}
		return i;
	}
	public static double linterp(double[] x, double[] y, double z){
		int i = binsearch(x,z);
		double dx = x[i+1] - x[i]; if(!(dx>0)) throw new Exception("binsearch did not work");
		double dy = y[i+1] - y[i];
		return y[i]+(dy/dx)*(z-x[i]);
	}

	public static double linterpInte(double[] x, double[] y, double z){
		if(x[0]==z)return 0.0;
		else{
		int k = binsearch(x,z);
		double S = 0, dx, dy;
		for (int i=0; i<k; i++){
			dx = x[i+1] - x[i]; if(!(dx>0)) throw new Exception("binsearch did not work");
			dy = y[i+1] - y[i];
			double p = dy/dx;
			S += dx*(y[i]+dx*p/2);
		}
		dx = z-x[k];
		dy = y[k+1]-y[k];
		double p_i = dy/dx;
		double S_int = S + dx*(y[k]+dx*p_i);
		
		return S_int;}
	}}
	//Part B below
public class qspline{
		vector x, y;
		vector b, c, p, dx;
		public qspline(vector xs, vector ys){
			x = xs.copy(); y = ys.copy();
			int n = xs.size;
			b = new vector(n-1);
			c = new vector(n-1);
			p = new vector(n-1);
			dx = new vector(n-1);
			for(int i = 0; i<n-1; i++){
				dx[i] = x[i+1]-x[i];
				p[i] = (y[i+1]-y[i])/dx[i];}
			c[0] = 0;
			for(int i = 0; i<n-2; i++)c[i+1] = (p[i+1]-p[i]-c[i]*dx[i])/dx[i+1];
			c[n-2]/=2;
			for(int i = n-3; i >=0; i--)c[i] =(p[i+1]-p[i]-c[i+1]*dx[i+1])/dx[i];
			for(int i = 0; i<n-1; i++)b[i] = p[i]-c[i]*dx[i];
			}
		public double evaluate(double z){
			int k = spline.binsearch(x,z);
			double s = y[k]+b[k]*(z-x[k])+c[k]*(z-x[k])*(z-x[k]);
			return s;
			}
		public double derivative(double z){
			int k = spline.binsearch(x,z);
			double sdif = b[k]+2*c[k]*(z-x[k]);
			return sdif;}
		public double integral(double z){
			int k = spline.binsearch(x,z);
			double S = 0, dx;
			for (int i=0; i<k; i++){
				dx = x[i+1]-x[i];
				S+=dx*(y[i]+dx*(b[i]/2+dx*c[i]/3));}
			dx = z-x[k];
			double s_int = S + dx*(y[k]+dx*(b[k]/2+dx*c[k]/3));
			return s_int;}
	}



		

