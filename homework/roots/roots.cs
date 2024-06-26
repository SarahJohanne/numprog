using System;
using static System.Console;
using static System.Math;
using static matrix;
using static vector;
using static QRGS;
public static class Nroots{

static public vector newton(Func<vector,vector>f, vector start, double acc=1e-2){
	int steps=0;
	int steps_max=10000;
	vector x = start.copy();
	vector fx=f(x), z, fz;
	do{
		steps+=1;
		if(fx.norm() < acc) break;
		matrix J = jacobian(f,x,fx);//bygges ud fra "opskrift" længere nede.
		vector Dx = solve(J,-fx);
		double lambda = 1;
		do{
			z = x+lambda*Dx;
			fz = f(z);
			if(fz.norm() < (1-lambda/2)*fx.norm())break;
			if(lambda<1/64.0) break;
			lambda/=2;
		}while(true);
		x=z; fx=fz;
	}while(true && steps<steps_max);
return x;
}//Newton

public static matrix jacobian (Func<vector, vector> f, vector x, vector fx=null, vector dx=null){
	if(dx==null) dx=x.map(xi => Abs(xi)*Pow(2,-26));
	if(fx==null) fx = f(x);
	matrix J = new matrix(x.size);
	for(int j=0; j<x.size; j++){
	x[j]+=dx[j];
	vector df=f(x)-fx;
	for(int i=0; i<x.size;i++) J[i,j]=df[i]/dx[j];
	x[j]-=dx[j];
	}
	return J;
}//jacobian
}
