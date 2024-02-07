using static System.Console;
using static System.Math;
class main{
public static bool approx(double a, double b, double acc=1e-9, double eps=1e-9){
        if(Abs(b-a) <= acc) return true;
        if(Abs(b-a) <= System.Math.Max(Abs(a),Abs(b))*eps) return true;
        return false;
}
public static int Main(){
	/*int i=1;
	while(i+1>i){i++;
	}
	Write($"My max int = {i}\n");
	
	while(i-1<i){i--;
	}
	Write($"My min int = {i}\n");
	*/
	double x=1;
	while(1+x!=1){x/=2;
	}
	x*=2;
	Write($"My machine epsilon for double = {x}.\n	Expected it to be {System.Math.Pow(2,-52)}.\n");
	float y=1F;
       	while((float)(1F+y) != 1F){y/=2F;
	}
	y*=2F;
	Write($"My machine epsilon for float = {y}.\n	Expected it to be {System.Math.Pow(2,-23)}.\n");
	double epsilon = System.Math.Pow(2,-52);
	double tiny = epsilon/2;
	double a=1+tiny+tiny;
	double b=tiny+tiny+1;
	Write($"a = {a} and b={b}\n");
	Write($"a==b ? {a==b}\n");
	Write($"a>1 ? {a>1}\n");
	Write($"b>1 ? {b>1}\n");
	double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
	double d2 = 8*0.1;
	Write($"d1={d1}={d1:e15}\n d2={d2}={d2:e15}\n d1==d2? =>{d1==d2}\n");
	Write($"a==b w. approx func gives {approx(d1,d2)}\n");
	return 0;
}
}
