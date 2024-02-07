using System;
class main{

static int Main(){
	double sqrt2=Math.Sqrt(2.0);
	Console.Write($"sqrt2^2 = {sqrt2*sqrt2} (should equal 2)\n");
	double power5 =Math.Pow(2.0, 0.2);
	Console.Write($"power5 = {power5*power5*power5*power5*power5} (2)\n");	
	double epi = Math.Pow(Math.E, Math.PI);
	Console.Write($"e^pi = {epi} (should be 23.14...)\n");
	double pie = Math.Pow(Math.PI,Math.E);
	Console.Write($"pi^e = {pie} (should be 22.459...)\n");
	double prod=1;
	for(double x=1;x<10;x++){
	Console.Write($"fgamma({x})={sfuns.fgamma(x)} \t {x-1}!={prod}\n");
	prod*=x;
	}	
       return 0;
	}//Main
}//class main

