using System;
using static System.Console;
using static System.Math;

public class main{

public static void Main(){
	double Q, d=1e-4, eps=1e-4;
	Func<double, double> f;
	int n=0;

	f = x=>{n++; return Sqrt(x);};
	n=0; Q = matlib.integrate(f,0,1,d,eps);
	WriteLine($"integrate from 0 to 1 Sqrt(x) = {Q:g6} npoints={n}");
	n=0; Q = matlib.ccintegrate(f,0,1,d,eps);
	WriteLine($"cc-integrate from 0 to 1 Sqrt(x) = {Q:g6} npoints={n}");


	

	f = x=>{n++; return 1/Sqrt(x);};
	n=0; Q = matlib.integrate(f,0,1,d,eps);
	WriteLine($"integrate from 0 to 1 1/Sqrt(x) = {Q:g7} npoints={n}");
	n=0; Q = matlib.ccintegrate(f,0,1,d,eps);
	WriteLine($"cc-integrate from 0 to 1 1/Sqrt(x) = {Q:g7} npoints={n}");

	

	f = x=>{n++; return 4*Sqrt(1-x*x);};
	n=0; Q = matlib.integrate(f,0,1,d,eps);
	WriteLine($"integrate from 0 to 1 4*Sqrt(1-x*x) = {Q:g8} npoints={n}");
	n=0; Q = matlib.ccintegrate(f,0,1,d,eps);
	WriteLine($"cc-integrate from 0 to 1 4*Sqrt(1-x*x) = {Q:g8} npoints={n}");


	
	f = x=>{n++; return Log(x)/Sqrt(x);};
	n=0; Q = matlib.integrate(f,0,1,d,eps);
	WriteLine($"integrate from 0 to 1 ln(x)/Sqrt(x) = {Q:g9} npoints={n}");
	n=0; Q = matlib.ccintegrate(f,0,1,d,eps);
	WriteLine($"cc-integrate from 0 to 1 ln(x)/Sqrt(x) = {Q:g9} npoints={n}");

WriteLine($"cc-integration has fewer evaluations for integrals with integrable divergencies at the end of intervals.");

}
}//main
