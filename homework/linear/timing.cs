using static System.Console;
class timing{
public static int Main(string[] args){
        int N = args;
	System.Random random = new System.Random(4);
	matrix A = new matrix(N);
	for (int i=0; i<N; i++){
		for (int j=0; j<N; j++){A[i,j] = random.NextDouble();}
	}
	QRGS.decomp(A);
return 0;
}
}
