using System;
using static System.Console;

static class main{
    static void Main(){
        int n = 5;
	    matrix A = new matrix(n);
	    matrix I = new matrix(n);
	    for (int i=0; i<A.size1; i++){
		    for (int j=0; j<A.size1; j++){
			    if(i<=j){A[i,j]=i*n-i*(i+1)/2+j;}
			    else{A[i,j]=j*n-j*(j+1)/2+i;}
			    I[i,j] = 0;
			    I[i,i] = 1;
		}}
        WriteLine($"---- Creating symmetric matrix A and unit matrix I ----");
	    A.print("A = ");
	    I.print("I = ");

        WriteLine($"\n----------------Calculating D, V and w----------------");
	    (vector w, matrix V, matrix A_new) = jacobi.cyclic(A);
	    A_new.print("D = ");
	    V.print("V = ");
        w.print("w = ");

        WriteLine($"\n--------------Testing the implementation--------------");
	    matrix VT = V.transpose();
        matrix VDVT = V*A_new*VT;
	    VDVT.print("V*D*V^T = ");
        WriteLine($"It should equal:");
        A.print("A = ");
        WriteLine("\n\n");

        matrix VTAV = VT*A*V;
	    VTAV.print("V^T*A*V = ");
        WriteLine($"It should equal:");
        A_new.print("D = ");
        WriteLine("\n\n");
	    
	    matrix VTV = VT*V;
	    VTV.print("V^T*V = ");
        WriteLine($"It should equal:");
        I.print("I = ");

	    //matrix VVT = V*VT;
	    //VVT.print("V*V^T = ");
	    
    }
}