using System;
using static System.Console;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

public class main{
	public class data { public int a,b; public double sum;}
	public static void harm(object obj){
		var arg = (data)obj;
		arg.sum=0;
		for(int i=arg.a;i<arg.b;i++)arg.sum+=1.0/i;
		}

	public static int Main(string[] args){
		int nthreads = 1, nterms = (int)1e8;
		foreach(var arg in args) {
		   var words = arg.Split(':');
		   if(words[0]=="-threads") nthreads=int.Parse(words[1]);
	   	if(words[0]=="-terms"  ) nterms  =(int)float.Parse(words[1]);
	   	}
	data[] datas = new data[nthreads];
	for(int i=0;i<nthreads;i++) {
	   datas[i] = new data();
	   datas[i].a = 1 + nterms/nthreads*i;
	   datas[i].b = 1 + nterms/nthreads*(i+1);
	   }
	datas[datas.Length-1].b=nterms+1;

	var threads = new System.Threading.Thread[nthreads];
	for(int i=0;i<nthreads;i++) {
  		threads[i] = new System.Threading.Thread(harm);
   		threads[i].Start(datas[i]);
		}

	foreach(var thread in threads) thread.Join();

	double total=0;
	foreach(var p in datas){total+=p.sum;}
	WriteLine($"Main:total= {total}");
	/*
	double sum=0;
	System.Threading.Tasks.Parallel.For( 1, nterms+1, (int i) => sum+=1.0/i );
	WriteLine($"Main:sum = {sum}\n");
	/* slower than the other one */

	var sum = new System.Threading.ThreadLocal<double>( ()=>0, trackAllValues:true);
	System.Threading.Tasks.Parallel.For( 1, nterms+1, (int i)=>sum.Value+=1.0/i );
	double totalsum=sum.Values.Sum();
	WriteLine($"Main: Sum = {totalsum}");
	//Korrekt resultat, hurtigere end forrige, men langsommere end første
return 0;
}
}
