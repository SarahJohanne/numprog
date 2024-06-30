using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;

public class main
{
    public static void Main(string[] args)
    {
        // Create the neural network with 5 hidden neurons
        ann network = new ann(5);

        // Define the function to approximate
        Func<double, double> g = x => Math.Cos(5 * x - 1) * Exp(-x * x);

        // Sample points from the target function
        int ns = 10;
        vector xs = new vector(ns);
        vector ys = new vector(ns);
        double xmin = -1.0;
        double xmax = 1.0;

        for (int i = 0; i < ns; i++)
        {
            xs[i] = xmin + (xmax - xmin) * i / (ns - 1);
            ys[i] = g(xs[i]);
        }
        for (int i = 0; i < ns; i++)
        {
            WriteLine($"{xs[i]} {ys[i]}");
        }

        WriteLine("\n");

        network.train(xs, ys, eps: 10000, learningRate: 0.01, lambda: 0.01);

        WriteLine("\nNetwork response after training:\n");
        for (double xjs = xmin; xjs <= xmax; xjs += 1.0 / 64)
        {
            double yjs = network.response(xjs);
            WriteLine($"{xjs} {yjs}");
        }
    }
}
