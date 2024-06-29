using System;
using static System.Console;
using static System.Math;
using static matrix;
using static vector;
using static QRGS;
//using static ode;
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

public static (genlist<double>, genlist<vector>) Schroedinger(double E, double r_min, double r_max, double acc, double eps)
        {
            Func<double, vector, vector> hydrogen = delegate (double r, vector h)
            {
                vector dh = new vector(2);
                dh[0] = h[1];
                dh[1] = -2 * h[0] * (1 / r + E);
                return dh;
            };
            vector start_hydrogen = new vector(r_min - r_min * r_min, 1 - 2 * r_min);
            var result = ODE.driver(hydrogen, (r_min, r_max), start_hydrogen, acc:acc, eps:eps);
            return result;
        }
public static double energy(double r_min, double r_max, double acc, double eps){
	Func<vector, vector> M = delegate (vector e)
        {
            var (r, f) = Schroedinger(e[0], r_min, r_max, acc:acc, eps:eps);
            return new vector(f[f.size - 1][0]);
        };
	vector E0_guess = new vector(-0.6);
    vector energies = Nroots.newton(M, E0_guess);
    double E0 = energies[0];
	return E0;
}
}
/*
public static class Schroedinger{

	public static double M(Func<double, vector, vector> wavefunction, double, r_min, double r_max, double E){
	vector f_start = new vector(r_min-r_min*r_min,  1-2*r_min);
	var (rs, fs) = ODE.driver(wavefunc, (r_min, r_max), f_start);
	vector fs_max = fs[fs_max.Count-1][0];
}
}



*/