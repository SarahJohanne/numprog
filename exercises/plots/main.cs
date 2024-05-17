class main{
public static int Main(){
	for (double x=0.001;x<=3;x+=0.125){
	System.Console.WriteLine($"{x} {sfuns.erf(x)}");	
	}
	System.Console.WriteLine($"\n");
	for (double x=0.125;x<=3;x+=0.126){
	System.Console.WriteLine($"{x} {sfuns.gamma(x)}");	
	}
	System.Console.WriteLine($"\n");
	for (double x=0.001;x<=3;x+=0.125){
	System.Console.WriteLine($"{x} {sfuns.lngamma(x)}");	
	}

return 0;
}

}
