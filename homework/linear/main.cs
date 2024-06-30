using static System.Console;
static class main{
	static void Main(){
		var random = new System.Random(4);
		int m = 3; int n=5;
		matrix A = new matrix(n,m);
		for (int  i= 0; i < n ; i++){
    			for (int j = 0; j < m ; j++){
				A[i,j] = random.NextDouble();}}
		A.print("A = ");
		(matrix Q, matrix R) = QRGS.decomp(A);
		Q.print("Q = ");
		R.print("R = ");
		matrix QT = Q.transpose();
		matrix tproduct = QT*Q;
		tproduct.print("QTQ =");
		matrix qrproduct = Q*R;
		qrproduct.print("Q*R = ");


		WriteLine($" \n Testing solve function:");
		matrix A2 = new matrix(n);
		double[] b = new double[n];
		for (int i=0; i<n; i++){
			b[i] = random.NextDouble();
			for (int j=0; j<n; j++){
				A2[i,j] = random.NextDouble();
			}
		}
		A2.print("A = ");
		WriteLine("b = [{0}]", string.Join(",", b));
		(matrix Q2, matrix R2) = QRGS.decomp(A2);
		matrix QR = Q2*R2;
		double[] x = QRGS.solve(QR,b);
		WriteLine("x = [{0}]", string.Join(",", x));
		double[] Ax = A2*x;
		WriteLine("Ax = [{0}]", string.Join(",", Ax));
		
	
		WriteLine($" \n Testing inverse function:");
		matrix A3 = new matrix(n);
		for (int  i= 0; i < n ; i++){
    		for (int j = 0; j < n ; j++){
				A3[i,j] = random.NextDouble();}}
		A3.print("A = ");
		(matrix Q3, matrix R3) = QRGS.decomp(A3);
		Q3.print("Q = ");
		R3.print("R = ");
		matrix B = QRGS.inverse(Q3, R3);
		B.print("B = ");
		matrix AB = A3*B;
		AB.print("AB = ");

		WriteLine($" See Plot.times.svg for the operations count for QR decomposition");
	}
}




				
