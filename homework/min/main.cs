using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.IO;
//using static genlist;


public static class main
{
    public static void Main()
    {
        // Task A

        //Rosenbrock's valley function
        int nR = 0;
        Func<vector, double> R = x => { nR++; return Pow(1 - x[0], 2) + 100 * Pow(x[1] - x[0] * x[0], 2); };

        //Himmelblau's function
        int nH = 0;
        Func<vector, double> H = x => { nH++; return Pow(x[0] * x[0] + x[1] - 11, 2) + Pow(x[0] + x[1] * x[1] - 7, 2); };

        vector start = new vector(10, 10);
        var minima_R = minimize.newton(R, start);
        var minima_H = minimize.newton(H, start);
        WriteLine($"-----------------Part A-------------");
        WriteLine($"A minimum has been found for Rosenbrock using {nR} steps at x = {minima_R[0]}, y = {minima_R[1]}");
        WriteLine($"The value of function at minimum was: {R(minima_R)}");
        WriteLine($"\n\n");
        WriteLine($"A minimum has been found for Himmelblau using {nH} steps at x = {minima_H[0]}, y = {minima_H[1]}");
        WriteLine($"The value of function at minimum was: {H(minima_H)}");
        
        //Task B
        WriteLine($"-----------------Part B-------------");
        var energy = new genlist<double>();
        var signal = new genlist<double>();
        var error = new genlist<double>();
        var separators = new char[] { ' ', '\t' };
        var options = StringSplitOptions.RemoveEmptyEntries;
        /*do
        {
            string line = In.ReadLine();
            if (line == null) break; */
        foreach (var line in File.ReadLines("higs-data.txt")){
            string[] words = line.Split(separators, options);
            energy.add(double.Parse(words[0]));
            signal.add(double.Parse(words[1]));
            error.add(double.Parse(words[2]));
        } //while (true);

        Func<vector, double> BW = x =>
        {
            double E = x[3]; double m = x[0]; double w = x[1]; double A = x[2];
            return A / (Pow(E - m, 2) + w * w / 4);
        };
        int n = 0;
        Func<vector, double> D = x =>
        {
            n++;
            double sum = 0.0;
            double m = x[0];
            double w = x[1];
            double A = x[2];
            for (int i = 0; i < energy.size; i++)
            {
                double e = energy[i];
                double s = signal[i];
                double err = error[i];
                vector args = new vector(m, w, A, e);
                sum += Pow((BW(args) - s) / err, 2);
            }
            return sum;
        };

        vector Higgs_guess = new vector(125, 10, 10);
        vector fits = minimize.newton(D, Higgs_guess, 1e-4);
        WriteLine($"\nMass of the Higgs boson: m = {fits[0]:f2} GeV/c^2");
        WriteLine($"Experimental width: Gamma = {fits[1]}");
        WriteLine($"Theoretical mass of Higgs boson: m = 125.11 +- 0.11 GeV/c^2");
        WriteLine($" number of calls = {n++}\n\n");

        for(int i = 100; i <=energy[energy.size-1]; i++){
            vector args = new vector(fits[0], fits[1], fits[2],i);
            WriteLine($"{i} {BW(args)}");
        }   

        //Part C:

        vector start_C = new vector(10, 10);
        var minima_R_C = minimize.newtonC(R, start_C);
        var minima_H_C = minimize.newtonC(H, start_C);
        WriteLine($"\n-----------------Part B-------------");
        WriteLine($"\nFor original Newton, minimum has been found for Rosenbrock using 303 steps at x = {minima_R[0]}, y = {minima_R[1]}");
        WriteLine($"For new Newton, minimum has been found for Rosenbrock using {nR} steps at x = {minima_R_C[0]}, y = {minima_R_C[1]}");
        WriteLine($"The value of function at minimum was in original: {R(minima_R)} and in new: {R(minima_R_C)}");
        WriteLine($"\n");
        WriteLine($"For original Newton, a minimum has been found for Himmelblau using 115 steps at x = {minima_H[0]}, y = {minima_H[1]}");
        WriteLine($"A minimum has been found for Himmelblau using {nH} steps at x = {minima_H_C[0]}, y = {minima_H_C[1]}");
        WriteLine($"he value of function at minimum was in original: {H(minima_H)} and in new: {H(minima_H_C)}");
        
    }
}