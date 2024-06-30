using System;
using static System.Console;
using static System.Math;

static class main{
    static void Main(){
        int ns = 30;
        double[] x_test = new double[ns];
        double[] y_test = new double[ns];
        for(int i = 0; i<x_test.Length; i++){
            x_test[i] = i/(2*PI);
            y_test[i] = Cos(x_test[i]); }

        //testing B1 interpolation
        double x_test_max = x_test[x_test.Length-1];
        double z = x_test[0];
        int npoints = 100; //total number of points found by interpolation
        double[] Bpoints = new double[npoints];
        double[] xpoints = new double[npoints];
        double step = (x_test_max-x_test[0]) / (double)npoints;
        for(int i = 0; i<npoints; i++){
            Bpoints[i] = interpolators.B1interp(x_test, y_test, z);
            xpoints[i] = z;
            z += step;
        }
        WriteLine($"\n");
        for(int i=0; i<xpoints.Length; i++){
            WriteLine($"{xpoints[i]} {Bpoints[i]}"); }
        WriteLine($"\n");
        for(int i=0; i<x_test.Length; i++){
            WriteLine($"{x_test[i]} {y_test[i]}"); }
       
        
        //testing interpolation class
        var testinterp = new interpolation(x_test, y_test); //using same function as before, to make indikative plots proving class works.
        (double[] x_new, double[] y_new) = testinterp.evaluate(100, interpStyle.B1interp);
        (double[] p_x, double[] p_y) = testinterp.evaluate(100, interpStyle.Pinterp);
        WriteLine($"\n");
        for(int i=0; i<x_new.Length; i++){
            WriteLine($"{x_new[i]} {y_new[i]}"); }
        WriteLine($"\n");
        for(int i=0; i<p_x.Length; i++){
            WriteLine($"{p_x[i]} {p_y[i]}"); }
        

        //Showing the Runge's phenomenon
        double[] x_Runge = { -1.0, -0.8, -0.6, -0.4, -0.2, 0.0, 0.2, 0.4, 0.6, 0.8, 1.0};
        double[] y_Runge = new double[x_Runge.Length];
        for(int i = 0; i<x_Runge.Length; i++){
            y_Runge[i] = 1/(1+25*x_Runge[i]*x_Runge[i]); //The Runge function
             }
        var Rungeinterp = new interpolation(x_Runge, y_Runge);
        (double[] x_B1R, double[] y_B1R) = Rungeinterp.evaluate(400, interpStyle.B1interp);
        (double[] x_pR, double[] y_pR) = Rungeinterp.evaluate(400, interpStyle.Pinterp);
        WriteLine($"\n");
        for(int i=0; i<x_B1R.Length; i++){
            WriteLine($"{x_B1R[i]} {y_B1R[i]} {x_B1R.Length}"); }
        WriteLine($"\n");
        for(int i=0; i<x_pR.Length; i++){
            WriteLine($"{x_pR[i]} {y_pR[i]} {y_pR.Length}"); }
        WriteLine($"\n");
        for(int i=0; i<x_Runge.Length; i++){
            WriteLine($"{x_Runge[i]} {y_Runge[i]}"); }
    }

}