using System;
using static System.Console;
using static System.Math;
using static QRGS;
using static vector;
using static matrix;
public class minimize{
public static vector newton( Func<vector, double> phi, vector start, double acc=1e-3){
    int nsteps = 0;
    vector x = start.copy();
    int nmax = 1000;
    do{
        nsteps+=1;
        var dphi = gradient(phi,x);
        if(dphi.norm() < acc || nsteps>=nmax) break; // Then x is near enough the minima, or we have tried for too long.
        var H = hessian(phi, x);
        var dx = solve(H,-dphi); //QRGS makes QR decomposition of H and then solves.
        double lambda = 1, phix=phi(x);
        do{
            if( phi(x+lambda*dx) <phix) break; //if step accepted, ends here.
            if( lambda <1.0/1024) break; //if lambda is small enough, step is accepted eventhoug bad.
            lambda/=2;
        }while(true);
        x+=lambda*dx; //new step made.
    }while(true);
    return x;
}//newton

public static vector gradient(Func<vector, double> phi, vector x){
    vector dphi = new vector(x.size);
    double phix = phi(x);
    double sqrt_eps = Pow(2,-26);
    for(int i=0; i<x.size;i++){
        double dx = Abs(x[i])*sqrt_eps;
        x[i]+=dx;
        dphi[i] = (phi(x)-phix)/dx;
        x[i]-=dx;
    }
    return dphi;
}

public static matrix hessian(Func<vector, double> phi, vector x){
    matrix H = new matrix(x.size);
    vector dphix = gradient(phi,x);
    for(int j = 0; j<x.size; j++){
        double dx = Abs(x[j])*Pow(2,-26);
        x[j] += dx;
        vector ddphi = gradient(phi,x)-dphix;
        for(int i=0; i<x.size;i++) H[i,j]=ddphi[i]/dx;
        x[j]-=dx;
    }
return (H+H.T)/2;
}
// for part C:
public static vector gradientC(Func<vector,double> phi,vector x){
	vector dphi = new vector(x.size);
    vector y = x.copy();
	double dphix = phi(x); 
	for(int i=0;i<x.size;i++){
		double dx=Max(Abs(x[i]),1)*Pow(2,-26);
		y[i]-=dx;
        x[i]+=dx;
		dphi[i]=(phi(x)-phi(y))/(2*dx);
		x[i]-=dx;
        y[i] +=dx;
	}
	return dphi;
}
public static matrix hessianC(Func<vector, double> phi, vector x){
    matrix H = new matrix(x.size);
    for(int j = 0; j<x.size; j++){
        double dx = Abs(x[j])*Pow(2,-26);
        x[j] += dx;
        vector dphi_plus = gradient(phi,x);
        x[j] -=2*dx;
        vector dphi_minus = gradient(phi,x);
        vector ddphi = (dphi_plus - dphi_minus)/(2*dx);
        for(int i=0; i<x.size;i++) H[i,j]=ddphi[i];// /dx;
    }
return (H+H.T)/2;
}
public static vector newtonC( Func<vector, double> phi, vector start, double acc=1e-3){
    int nsteps = 0;
    vector x = start.copy();
    int nmax = 1000;
    do{
        nsteps+=1;
        var dphi = gradientC(phi,x);
        if(dphi.norm() < acc || nsteps>=nmax) break; // Then x is near enough the minima, or we have tried for too long.
        var H = hessianC(phi, x);
        var dx = solve(H,-dphi); //QRGS makes QR decomposition of H and then solves.
        double lambda = 1, phix=phi(x);
        do{
            if( phi(x+lambda*dx) <phix) break; //if step accepted, ends here.
            if( lambda <1.0/1024) break; //if lambda is small enough, step is accepted eventhoug bad.
            lambda/=2;
        }while(true);
        x+=lambda*dx; //new step made.
    }while(true);
    return x;
}//newton
}