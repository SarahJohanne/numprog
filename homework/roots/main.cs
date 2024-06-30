using System;
using static System.Console;
using static System.Math;

static class main
{
    static void Main()
    {
        // Task A - Simple One- and Two-Dimensional Equations
        TestSimpleEquations();

        // Task A - Rosenbrock's Valley Function
        TestRosenbrock();

        // Task A - Himmelblau's Function
        TestHimmelblau();

        // Task B - Ground State Energy Calculation
        CalculateGroundStateEnergy();
    }

    static void TestSimpleEquations()
    {
        try
        {
            // One-Dimensional Equation
            Func<vector, vector> f1 = x => new vector(2 * x[0] + 3);
            vector guess1 = new vector(-3);
            vector root1 = Nroots.Newton(f1, guess1);
            WriteLine($"Root to f = 2*x + 3 is found as x={root1[0]}");

            // Two-Dimensional Equation
            Func<vector, vector> f2 = x => new vector(x[1] * x[0] + 3, 2 * x[1] - 4);
            vector guess2 = new vector(-3, -3);
            vector root2 = Nroots.Newton(f2, guess2);
            WriteLine($"Root to f = y*x+3 and f = 2*y-4 is found as x={root2[0]}, y={root2[1]}");
        }
        catch (OverflowException ex)
        {
            WriteLine($"Overflow exception: {ex.Message}");
        }
    }

    static void TestRosenbrock()
    {
        try
        {
            Func<vector, vector> R = x =>
            {
                double a = 1.0;
                double b = 100;
                return new vector(Pow(a - x[0], 2) + b * Pow(x[1] - x[0] * x[0], 2));
            };

            Func<vector, vector> R_diff = x =>
            {
                double a = 1.0;
                double b = 100;
                return new vector(
                    -2 * (a - x[0]) - 4 * b * x[0] * (x[1] - x[0] * x[0]),
                    2 * b * (x[1] - x[0] * x[0])
                );
            };

            vector guessR = new vector(0.5, 0.5);
            vector rootR = Nroots.Newton(R_diff, guessR);
            WriteLine($"Extremum for Rosenbrock's valley is found at x={rootR[0]:f1} y={rootR[1]:f1} with f = {R(rootR)[0]:f3}");
            WriteLine($"Theoretically, the value should be x=1 y=1, f(x,y)=0");
        }
        catch (OverflowException ex)
        {
            WriteLine($"Overflow exception: {ex.Message}");
        }
    }

    static void TestHimmelblau()
    {
        try
        {
            Func<vector, vector> H = x =>
            {
                return new vector(Pow(x[0] * x[0] + x[1] - 11, 2) + Pow(x[0] + x[1] * x[1] - 7, 2));
            };

            Func<vector, vector> H_diff = x =>
            {
                return new vector(
                    4 * x[0] * (x[0] * x[0] + x[1] - 11) + 2 * (x[0] + x[1] * x[1] - 7),
                    2 * (x[0] * x[0] + x[1] - 11) + 4 * x[1] * (x[0] + x[1] * x[1] - 7)
                );
            };

            vector guessH = new vector(-3.9, -3.5);
            vector rootH = Nroots.Newton(H_diff, guessH);
            WriteLine($"One of the minimums for Himmelblau's function is found at x={rootH[0]:f6} y={rootH[1]:f6} with f = {H(rootH)[0]:f1}");
            WriteLine($"Theoretically, the value should be x=-3.779310 y=-3.283186, f(x,y)=0.0");
        }
        catch (OverflowException ex)
        {
            WriteLine($"Overflow exception: {ex.Message}");
        }
    }

    static void CalculateGroundStateEnergy()
    {
        try
        {
            WriteLine("--------- Task B -------------");
            double r_min = 1e-4;
            double r_max = 8.0;
            double acc = 0.01;
            double eps = 0.01;

            double E0 = Nroots.CalculateEnergy(r_min, r_max, acc, eps);
            WriteLine($"Ground state energy for r_min = {r_min} and r_max = {r_max} Bohr radius is: {E0} Hartree.");
            WriteLine("The theoretical value for E0 is -0.5 Hartree.\n\n");

            var (rs, fs) = Nroots.Schroedinger(E0, r_min, r_max, acc, eps);
            WriteLine("r and f(r) values:");
            for (int i = 0; i < rs.size; i++) WriteLine($"{rs[i]} {fs[i][0]}");
            WriteLine("\n");

            WriteLine("r and r*exp(-r) values:");
            for (int i = 0; i < rs.size; i++) WriteLine($"{rs[i]} {rs[i] * Exp(-rs[i])}");
            WriteLine("\n");

            WriteLine("Varying r_min:");
            for (double R_min = 0.4; R_min > 1e-4; R_min -= 1.0 / 64)
            {
                double E0_rmin = Nroots.CalculateEnergy(R_min, r_max, acc, eps);
                WriteLine($"{R_min} {E0_rmin}");
            }
            WriteLine("\n");

            WriteLine("Varying r_max:");
            for (double R_max = 1.4; R_max < 8; R_max += 1.0 / 8)
            {
                double E0_rmax = Nroots.CalculateEnergy(r_min, R_max, acc, eps);
                WriteLine($"{R_max} {E0_rmax}");
            }
            WriteLine("\n");

            WriteLine("Varying eps:");
            for (double eps_x = 0.15; eps_x > 1e-6; eps_x -= 1.0 / 256)
            {
                double E0_eps_x = Nroots.CalculateEnergy(r_min, r_max, acc, eps_x);
                WriteLine($"{eps_x} {E0_eps_x}");
            }
            WriteLine("\n");

            WriteLine("Varying acc:");
            for (double acc_x = 0.15; acc_x > 1e-6; acc_x -= 1.0 / 256)
            {
                double E0_acc_x = Nroots.CalculateEnergy(r_min, r_max, acc_x, eps);
                WriteLine($"{acc_x} {E0_acc_x}");
            }
        }
        catch (OverflowException ex)
        {
            WriteLine($"Overflow exception: {ex.Message}");
        }
    }
}