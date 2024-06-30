using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;

public class ann
{
    public int n; // number of hidden neurons
    public Func<double, double> f;
    public vector p; // network parameters

    // Constructor
    public ann(int n)
    {
        f = x => x * Exp(-x * x);
        this.n = n;
        this.p = new vector(3 * n);
    }

    //Initialization (Xavier)
    private void Initialization()
    {
        var random = new Random();
        for (int i = 0; i < n; i++)
        {
            p[3 * i] = 0; // Initialize ai
            p[3 * i + 1] = 1; // Initialize bi to 1 for simplicity
            p[3 * i + 2] = random.NextDouble() * Sqrt(2.0 / n); // Initialize wi with Xavier initialization
        }
    }

    // Response function
    public double response(double x)
    {
        double sum = 0.0;
        for (int i = 0; i < n; i++)
        {
            double ai = p[3 * i];
            double bi = p[3 * i + 1];
            double wi = p[3 * i + 2];
            sum += f((x - ai) / bi) * wi;
        }
        return sum;
    }

    // Cost function for training
    public double costFunction(vector parameters, vector x, vector y, double lambda = 0.01)
    {
        this.p = parameters;
        double cost = 0.0;
        for (int i = 0; i < x.size; i++)
        {
            double xi = x[i];
            double yi = y[i];
            cost += Math.Pow(response(xi) - yi, 2);
        }
        // Add regularization term
        double regularization = 0.0;
        for (int i = 0; i < p.size; i++)
        {
            regularization += Math.Pow(p[i], 2);
        }
        cost += lambda * regularization;
        return cost;
    }

    // Compute Gradient
    public vector computeGradient(vector x, vector y, double lambda = 0.01)
    {
        vector grad = new vector(p.size);
        double delta = 1e-6;
        for (int i = 0; i < p.size; i++)
        {
            p[i] += delta;
            double costPlus = costFunction(p, x, y, lambda);
            p[i] -= 2 * delta;
            double costMinus = costFunction(p, x, y, lambda);
            grad[i] = (costPlus - costMinus) / (2 * delta);
            p[i] += delta; // Restore original value
        }
        // Add gradient of regularization term
        for (int i = 0; i < p.size; i++)
        {
            grad[i] += 2 * lambda * p[i];
        }
        return grad;
    }

    // Train method using gradient descent with regularization
    public void train(
        vector x,
        vector y,
        int eps = 10000,
        double learningRate = 0.01,
        double lambda = 0.01
    )
    {
        Initialization(); // Use Xavier initialization

        // Print initial parameters
        WriteLine("Initial parameters:");
        p.print();
        WriteLine($"Initial cost: {costFunction(p,x,y,lambda)}");

        // Training loop
        for (int epsi = 0; epsi < eps; epsi++)
        {
            vector grad = computeGradient(x, y, lambda);
            for (int i = 0; i < p.size; i++)
            {
                p[i] -= learningRate * grad[i];
            }
            

        }

        // Print optimized parameters
        // Error.WriteLine("Optimized parameters:");
        // p.print();

        // Final cost
        // Error.WriteLine($"Final cost: {costFunction(p, x, y, lambda)}");
    }
}
