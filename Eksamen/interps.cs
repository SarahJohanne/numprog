using System;
using static System.Console;
using static System.Math;

//Task A: implementing B1 interpolation (and polynomial)
public class interpolators
{
    public static double B1interp(double[] x, double[] y, double z, double acc = 1e-3)
    {
        if (z < x[0] || z > x[x.Length - 1]) throw new Exception("Out of interval, bad z");
        int n = x.Length;
        double numerator = 0;
        double denominator = 0, weight;
        for (int i = 0; i < n; i++)
        {
            if (Abs(x[i] - z) > acc) // To prevent a divission by zero
            {
                weight = Math.Pow(-1, i) / (z - x[i]);
                numerator += weight * y[i];
                denominator += weight;
            }
            else
            {
                numerator = y[i];
                denominator = 1;
                break;
            }
        }

        double B1 = numerator / denominator;
        return B1;
    }

    public static double Pinterp(double[] x, double[] y, double z)
    {
        if (z < x[0] || z > x[x.Length - 1]) throw new Exception("Out of interval, bad z");
        int n = x.Length;
        double s = 0, p;
        for (int i = 0; i < n; i++)
        {
            p = 1;
            for (int k = 0; k < n; k++)
            {
                if (k != i) p *= (z - x[k]) / (x[i] - x[k]);
            }
            s += y[i] * p;
        }
        return s;
    }


}
public enum interpStyle
{
    B1interp,
    Pinterp
}
public class interpolation
{
    double[] x, y;
    public interpolation(double[] xs, double[] ys)
    {
        x = xs; y = ys;
    }

public (double[], double[]) evaluate(int npoints, interpStyle style)
    {
        double step = (x[x.Length - 1] - x[0]) / (double)(npoints - 1);
        double[] y_new = new double[npoints];
        double[] x_new = new double[npoints];
        double z = x[0];
        double acc = 1 / (double)npoints;
        
        for (int i = 0; i < npoints; i++)
        {
            if (z > x[x.Length - 1]) z = x[x.Length - 1]; // Safeguard to prevent z from exceeding the last value in x

            x_new[i] = z;

            switch (style)
            {
                case interpStyle.B1interp:
                    y_new[i] = interpolators.B1interp(x, y, z, acc);
                    break;
                case interpStyle.Pinterp:
                    y_new[i] = interpolators.Pinterp(x, y, z);
                    break;
                default:
                    throw new Exception("Wrong interpolator type used");
            }

            z += step;
        }

        return (x_new, y_new);
    }
}

