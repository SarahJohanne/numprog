using System;
using static System.Console;
using static System.Math;

public class main
{

	static double corput(int n, int b)
	{
		double q = 0; double bk = (double)1 / b;
		while (n > 0) { q += (n % b) * bk; n /= b; bk /= b; }
		return q;
	}//corput sequence
	static vector halton(int n, int d)
	{
		vector x = new vector(d);
		int[] Base = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67 };
		int d_max = Base.Length;
		if (d > d_max)
		{
			throw new Exception("Bad dimension..");
		}
		for (int i = 0; i < d; i++)
		{
			x[i] = corput(n, Base[i]);
		}
		return x;
	}//halton sequence

	static (double, double) plainmc(Func<vector, double> f, vector a, vector b, int N)
	{
		int dim = a.size;
		double V = 1;
		for (int i = 0; i < dim; i++) { V *= b[i] - a[i]; }
		double sum = 0, sum2 = 0;
		var x = new vector(dim);
		var rnd = new Random();
		for (int i = 0; i < N; i++)
		{
			for (int k = 0; k < dim; k++)
			{
				x[k] = a[k] + rnd.NextDouble() * (b[k] - a[k]);
			}
			double fx = f(x);
			sum += fx;
			sum2 += fx * fx;
		}
		double mean = sum / N, sigma = Sqrt(sum2 / N - mean * mean);
		var result = (mean * V, sigma * V / Sqrt(N));
		return result;
	}//plain Monte Carlo

	static (double, double) quasirandom_mc(Func<vector, double> f, vector a, vector b, int N)
	{
		int dim = a.size;
		double V = 1;
		for (int i = 0; i < dim; i++) { V *= b[i] - a[i]; }
		double sum = 0, sum2 = 0;
		var x = new vector(dim);
		for (int i = 0; i < N; i++)
		{var halt = halton(i,dim);
		var rnd = new Random();
			for (int k = 0; k < dim; k++) x[k] = a[k] + rnd.NextDouble() * (b[k] - a[k]);
			double fx = f(x);
			sum += f(x);
		for (int k = 0; k < dim; k++) {x[k] = a[k] + halt[k] * (b[k] - a[k]);}
		sum2 += fx;
		}
		double mean1 = sum / N, mean2 = sum2 / N, mean = (mean1 + mean2) / N, sigma = Abs(mean1 - mean2);
		var result = (mean2 * V, sigma * V);
		return result;
	}//Quasi-random Monte Carlo

	public static void Main(string[] args)
	{
		int N = 1000;
		string MC_type = "";
		foreach (var arg in args)
		{
			var parts = arg.Split(new[] { ':' }, 2);
			if (parts.Length == 2)
			{
				var name = parts[0].TrimStart('-');
				var value = parts[1];

				if (name == "N")
				{
					N = Int32.Parse(value);
				}
				else if (name == "MC_type")
				{
					MC_type = value;
				}
				else
				{
					throw new Exception("Wrong syntax..");
				}
			}
		}

		switch (MC_type)
		{
			case "MC_test":
				Func<vector, double> f = z => z[0];
				vector a = new vector(0.0, 0.0);
				vector b = new vector(1.0, 2 * PI);
				(double area, double e) = plainmc(f, a, b, N);
				double exact = PI;
				WriteLine($"{N} {area} {e} {Abs(area - exact)}");
				break;
			case "MC_HW":
				Func<vector, double> g = z => 1.0 / ((1.0 - Cos(z[0]) * Cos(z[1]) * Cos(z[2])) * PI * PI * PI);
				vector ag = new vector(0.0, 0.0, 0.0);
				vector bg = new vector(PI, PI, PI);
				(double q, double err) = plainmc(g, ag, bg, N);
				double exact_g = 1.3932039296856768591842462603255;
				WriteLine($"{N} {q} {err} {Abs(q - exact_g)}");
				break;
			case "MC_QR":
				Func<vector, double> h = z => z[0];
				vector ah = new vector(0.0, 0.0);
				vector bh = new vector(1.0, 2*PI);
				(double area_h, double e_h) = quasirandom_mc(h, ah, bh, N);
				//(double area_plain, double e_plain) = plainmc(h, ah, bh, N);
				double exact_h = PI;
				WriteLine($"{N} {area_h} {e_h} {Abs(area_h - exact_h)}");
				break;
		}
	}//Main
}//main