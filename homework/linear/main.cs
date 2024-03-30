using static System.Console;
static class main{
	static int Main(){
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


		System.Console.Write($" testing solve function: \n");
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
		Q2.print("Q = ");
		R2.print("R = ");
		matrix QR = Q2*R2;
		QR.print("QR = ");
		double[] x = QRGS.solve(A2,b);
		WriteLine("x = [{0}]", string.Join(",", x));
		double[] Ax = A2*x;
		WriteLine("Ax = [{0}]", string.Join(",", Ax));
		double [] Rx = R2*x;
		WriteLine("Rx = [{0}]", string.Join(",", Rx));
		double [] QTb = Q2.transpose()*b;
		WriteLine("Q^Tb = [{0}]", string.Join(",", QTb));
		return 0;
	}}




				
