using System;
using static System.Console;
using static System.Math;
using static cmath;

static class main{

static int Main(){
		complex i = I;
		complex a = -1;
		complex sqrti = 1/sqrt(2)+I/sqrt(2);
		complex ei = cos(1)+I*sin(1);
		complex eipi = cos(PI);
		complex ii = cmath.exp(-PI/2);
		complex lni = I*PI/2;
		complex sinipi = I*System.Math.Sinh(PI);
		
		WriteLine($"sqrt(-1)={cmath.sqrt(a)} == {i}? - {i.approx(sqrt(a))}");
		WriteLine($"ln(i)={cmath.log(i)} == {lni}? - {lni.approx(cmath.log(i))}");
		WriteLine($"sqrt(i)={cmath.sqrt(i)} == {sqrti}? - {sqrti.approx(sqrt(i))}");
		WriteLine($"i^i={cmath.pow(i,i)} == {ii}? {ii.approx(cmath.pow(i,i))}");

		return 0;
}}
