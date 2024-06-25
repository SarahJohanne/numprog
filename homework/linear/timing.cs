using System;
using static System.Console;
public static class timing{
	public static void Main(string[] args){
        int N = 1;
		foreach(string arg in args){
			var words = arg.Split(':');
			if(words[0] == "-size")N = int.Parse(words[1]);
	}
	System.Random random = new System.Random(4);
	matrix A = new matrix(N);
	for (int i=0; i<N; i++){
		for (int j=0; j<N; j++){A[i,j] = random.NextDouble();}
	}
	QRGS.decomp(A);
}
}
