using System;
using static System.Console;
using static System.Math;

static class main{
    static void Main(){
        //Task A
        //Testing with simple one- and two-dimensional equations
        Func<vector, vector>f1 = delegate(vector x){
            vector y = new vector(1);
            y[0] = 2*x[0]+3;
            return y;};
        vector gæt1 = new vector(1);
        gæt1[0] = -3;
        vector root = Nroots.newton(f1, gæt1);
        WriteLine($"root to f = 2*x + 3 is found as x={root[0]}");

        Func<vector, vector>f2 = delegate(vector x){
          vector y = new vector(2);
            y[0] = x[1]*x[0]+3;
            y[1] = 2*x[1]-4;
            return y;};
        vector gæt2 = new vector(2);
        gæt2[0] = -3;
        gæt2[1] = -3;
        vector root2 = Nroots.newton(f2, gæt2);
        WriteLine($"root to f = y*x+3 and f = 2*y-4 is found as x={root2[0]}, y={root2[1]}");

        //Rosenbrock's valley function
        Func<vector, vector>R = delegate(vector x){
            vector y = new vector(1);
            double a = 1.0;
            double b = 100;
            y[0] = Pow(a-x[0],2) + b*Pow(x[1]-x[0]*x[0],2);
            return y;};

        Func<vector, vector>R_diff = delegate(vector x){
            vector y = new vector(2);
            double a = 1.0;
            double b = 100;
            y[0] = (-1)*2*(a-x[0])-4*b*x[0]*(x[1]-x[0]*x[0]);
            y[1] = 2*b*(x[1]-x[0]*x[0]);
            return y;};
        vector gætR = new vector(2);
        gætR[0] = 0.5;
        gætR[1] = 0.5;

        vector rootR = Nroots.newton(R_diff,gætR);
        WriteLine($"Extremum for Rosenbrock's valley is found at x={rootR[0]:f1} y={rootR[1]:f1} with f = {R(rootR)[0]:f3}");
        WriteLine($"Theoretically, the value should be x=1 y=1, f(x,y)=0");


        //Himmelblau's function
        Func<vector, vector>H = delegate(vector x){
            vector y = new vector(1);
            y[0] = Pow(x[0]*x[0] + x[1] - 11,2) + Pow(x[0] + x[1]*x[1] - 7,2);
            return y;};
        Func<vector, vector>H_diff = delegate(vector x){
            vector y = new vector(2);
            y[0] = 2*2*x[0]*(x[0]*x[0] + x[1] - 11) + 2*(x[0] + x[1]*x[1] - 7);
            y[1] = 2*(x[0]*x[0] + x[1] - 11) + 2*2*x[1]*(x[0] + x[1]*x[1] - 7);
            return y;};
        vector gætH = new vector(2);
        gætH[0] = -3.9;
        gætH[1] = -3.5;

        vector rootH = Nroots.newton(H_diff, gætH);
        WriteLine($"One of the minimums for Himmelblau's function  is found at x={rootH[0]:f6} y={rootH[1]:f6} with f = {H(rootH)[0]:f1}");
        WriteLine($"Theoretically, the value should be x=-3.779310 y=-3.283186, f(x,y)=0.0");

        //Task B
        


    }

}