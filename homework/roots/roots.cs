using System;
using static System.Math;
using static vector;
using static QRGS;

public static class Nroots
{
    public static vector Newton(Func<vector, vector> f, vector start, double acc = 1e-2)
    {
        int steps = 0;
        const int stepsMax = 10000;
        vector x = start.copy();
        vector fx = f(x), z, fz;

        do
        {
            steps++;
            if (fx.norm() < acc) break;
            matrix J = Jacobian(f, x, fx);
            vector Dx = solve(J, -fx);
            double lambda = 1;

            do
            {
                z = x + lambda * Dx;
                fz = f(z);
                if (fz.norm() < (1 - lambda / 2) * fx.norm()) break;
                if (lambda < 1 / 64.0) break;
                lambda /= 2;
            } while (true);

            x = z;
            fx = fz;
        } while (steps < stepsMax);

        return x;
    }

    public static matrix Jacobian(Func<vector, vector> f, vector x, vector fx = null, vector dx = null)
    {
        if (dx == null) dx = x.map(xi => Abs(xi) * Pow(2, -26));
        if (fx == null) fx = f(x);
        matrix J = new matrix(x.size);

        for (int j = 0; j < x.size; j++)
        {
            x[j] += dx[j];
            vector df = f(x) - fx;
            for (int i = 0; i < x.size; i++) J[i, j] = df[i] / dx[j];
            x[j] -= dx[j];
        }

        return J;
    }

    public static (genlist<double>, genlist<vector>) Schroedinger(double E, double r_min, double r_max, double acc, double eps)
    {
        Func<double, vector, vector> hydrogen = (r, h) =>
        {
            vector dh = new vector(2);
            dh[0] = h[1];
            dh[1] = -2 * h[0] * (1 / r + E);
            return dh;
        };

        vector startHydrogen = new vector(r_min - r_min * r_min, 1 - 2 * r_min);
        var result = ODE.driver(hydrogen, (r_min, r_max), startHydrogen, acc: acc, eps: eps);
        return result;
    }

    public static double CalculateEnergy(double r_min, double r_max, double acc, double eps)
    {
        Func<vector, vector> M = e =>
        {
            var (r, f) = Schroedinger(e[0], r_min, r_max, acc, eps);
            return new vector(f[f.size - 1][0]);
        };

        vector E0Guess = new vector(-0.6);
        vector energies = Newton(M, E0Guess);
        return energies[0];
    }
}