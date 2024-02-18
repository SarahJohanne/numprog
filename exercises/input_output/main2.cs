using static System.Console;
using static System.Math;
using System;
class main{
public static void Main(string[] args){
foreach(var arg in args){
	var split_options = StringSplitOptions.RemoveEmptyEntries;
	char[] delimiterChars = {' ', '\t', '\n'};
	var numbers = arg.Split(delimiterChars, split_options);
       foreach(var number in numbers){
	       double x = double.Parse(number);
	       Error.WriteLine($"x={x} sin(x)={Sin(x)} cos(x)={Cos(x)}");       
}
	
	}
}
}

