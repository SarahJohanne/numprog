using static System.Math;
public static class fit{
	//fitting function has been modified to match with task B
	public static (vector, matrix) lsfit (System.Func<double, double>[] fs, vector x, vector y, vector dy){
		int n = x.size, m=fs.Length;
		var A = new matrix (n,m);
		var b = new vector (n);
		for(int i=0; i<n; i++){
			b[i] = y[i]/dy[i];
			for(int k=0; k<m; k++)A[i,k] = fs[k](x[i])/dy[i];
		}
		vector c = QRGS.solve(A, b);
		(matrix Q, matrix R) = QRGS.decomp(A);
		matrix Rinv = QRGS.inverse(R);
		matrix sigma = Rinv*Rinv.transpose();
		return (c, sigma);
	
		
	}
}

