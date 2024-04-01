using System;
static class main{
static void Main(string[] args){
	double dr = 0;
	double rmax = 0;
	string plot = "";
	foreach(var arg in args){
		var parts = arg.Split(new[] {':'}, 2);
		if (parts.Length ==2){
			var name = parts[0].TrimStart('-');
			var value = parts[1];
		
		if (name=="dr"){
			dr = Convert.ToDouble(value);
		}
		else if (name=="rmax"){
			rmax = Convert.ToDouble(value);
		}	
		else if (name=="plot"){
			plot = value;
		}
		else {
			System.Console.Error.Write($"wrong syntax \n");}}}
	if (dr==0 || rmax==0){dr=0.3; rmax=10;}//System.Console.Error.Write($"values not assigned to rmax or dr \n");

	/*
	var random = new System.Random();
	matrix A = new matrix(n);
	matrix I = new matrix(n);
	for (int i=0; i<A.size1; i++){
		for (int j=0; j<A.size1; j++){
			if(i<=j){A[i,j]=i*n-i*(i+1)/2+j;}
			else{A[i,j]=j*n-j*(j+1)/2+i;}
			I[i,j] = 0;
			I[i,i] = 1;
		}}
	A.print("A = ");
	I.print("I = ");
	
	(vector w, matrix V, matrix A_new) = jacobi.cyclic(A);
	A_new.print("A' = D = ");
	V.print("V = ");
	matrix VT = V.transpose();
	matrix VTAV = VT*A*V;
	VTAV.print("V^T*A*V = ");
	matrix VDVT = V*A_new*VT;
	VDVT.print("V*D*V^T = ");
	matrix VTV = VT*V;
	VTV.print("V^T*V = ");
	matrix VVT = V*VT;
	VVT.print("V*V^T = ");
	w.print("w = ");*/

	int npoints = (int)(rmax/dr)-1;
	vector r = new vector(npoints);
	for(int i=0; i<npoints; i++)r[i]=dr*(i+1);
	matrix H = new matrix(npoints, npoints);
	for(int i=0; i<npoints-1; i++){
		H[i,i] = -2*(-0.5/(dr*dr));
		H[i,i+1] = 1*(-0.5/(dr*dr));
		H[i+1,i] = 1*(-0.5/(dr*dr));
	}
	H[npoints-1, npoints-1] = -2*(-0.5/(dr*dr));
	for(int i=0; i<npoints; i++)H[i,i]+=-1/r[i];

	(vector e, matrix V, matrix D) = jacobi.cyclic(H);
	//e.print("energierne er: ");
	//V.print("eigenvectorerne er: ");
	switch (plot){
		case "E0":
			System.Console.Out.Write($"{rmax} {dr} {e[0]} {e[1]} {e[2]} {e[3]}\n");
			break;
		case "f0":
			System.Func<double,double> f0 = z => 2*z*Math.Exp(-z);
			for(int i=0; i<r.size; i++)System.Console.Out.Write($"{r[i]} {V[i,0]/Math.Sqrt(dr)} {f0(r[i])}\n");
			System.Console.WriteLine("\n");
			break;
	}
}
	
}
