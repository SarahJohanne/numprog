using System;
using static System.Console;
public static class timing{
    public static void Main(string[] args){
        int N =1;
            foreach(string arg in args){
                var words = arg.Split(':');
                if(words[0] == "-size")N = int.Parse(words[1]);
            }
        System.Random random = new System.Random();
        double[] x = new double[N];
        double[] y = new double[N];
        for(int i=0; i<N; i++){
            x[i] = 10*random.NextDouble();
            y[i] = 10*random.NextDouble();
        }
        Array.Sort(x);
        double z = random.NextDouble()*(x[N-1]-x[0])+x[0];

        interpolators.B1interp(x, y,z);
    }
}