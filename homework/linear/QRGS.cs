using static System.Math;
using static matrix;
using static vector;
public static class QRGS{
	public static (matrix, matrix) decomp(matrix A){
		matrix Q = A.copy();
		matrix R = new matrix(A.size2, A.size2);
		int m = A.size2;
		for (int i=0; i<m; i++){
			R[i,i] = Q[i].norm();
			Q[i]/=R[i,i];
			for (int j=i+1; j<m; j++){
				R[i,j]=Q[i].dot(Q[j]);
				Q[j]-=Q[i]*R[i,j];
			}
		}
		return (Q,R);
	}
	public static vector solve (matrix A, vector b){
		(matrix Q, matrix R) = decomp(A);
		vector QTb = Q.transpose()*b;
		for (int i = QTb.size -1; i>=0; i--){
			double sum = 0;
			for (int k=i+1; k<QTb.size ; k++){
				sum+=R[i,k]*QTb[k];
			}
		QTb[i] = (QTb[i]-sum)/R[i,i]; 			
		}
		return QTb;	
	}
	public static double det (matrix A){
		if (A.size1 == A.size2){
			matrix R = decomp(A).Item2;
			double prod = 1;
			for (int i=0; i<R.size1; i++){
				prod*=R[i,i];
			}
			return prod;
		}
		System.Console.Write("$ Matrix is not m*m \n");
		return 0;
	}
	public static matrix inverse (matrix Q, matrix R){
		matrix B = R.copy();
		vector b = new vector(R.size1);
		for (int i=0; i<R.size1; i++){
			b[i]=0;}
		for (int j=0; j<R.size1; j++){
			b[j] = 1;
			B[j] = solve(Q*R, b);
			b[j] = 0;
		}
		return B;
	}	
}/* end class*/

