using System;
using static System.Console;
public static class timing{
	public static void Main(string[] args){
        int N = 0;
	N = Convert.ToInt32(args);
	System.Random random = new System.Random(4);
	matrix A = new matrix(N);
	for (int i=0; i<N; i++){
		for (int j=0; j<N; j++){A[i,j] = random.NextDouble();}
	}
	QRGS.decomp(A);
}
}
