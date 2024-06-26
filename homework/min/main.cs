using System;
using static System.Console;
using static System.Math;

public static class main{
    public static void Main(){
    // Task A

    //Rosenbrock's valley function
    int nR=0;
    Func<vector, double>R = x =>{nR++; return Pow(1-x[0],2) + 100*Pow(x[1]-x[0]*x[0],2);};
    
    //Himmelblau's function
    int nH=0;
    Func<vector, double>H = x =>{nH++; return Pow(x[0]*x[0]+x[1]-11,2) + Pow(x[0]+x[1]*x[1]-7,2);};

    vector start = new vector(10,10);
    var minima_R = minimize.newton(R,start);
    var minima_H = minimize.newton(H,start);
    WriteLine($"A minimum has been found for Rosenbrock using {nR} steps at x = {minima_R[0]}, y = {minima_R[1]}");
    WriteLine($"The value of function at minimum was: {R(minima_R)}");
    WriteLine($"\n\n");
    WriteLine($"A minimum has been found for Himmelblau using {nH} steps at x = {minima_H[0]}, y = {minima_H[1]}");
    WriteLine($"The value of function at minimum was: {H(minima_H)}");

    //Task B
    
}
}