using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using static vec;
class main{
	

	 static List<vec> GenerateRandomVectors(int numberOfVectors){
                        List<vec> vectors = new List<vec>();
                        Random random = new Random();
                        for (int i = 0; i < numberOfVectors; i++){
                                double x = random.NextDouble()*10-5;
                                double y = random.NextDouble()*10-5;
                                double z = random.NextDouble()*10-5;
                                vectors.Add(new vec(x, y, z));
				}

                return vectors;
                }
static int Main(){
        List<vec> vec_a = GenerateRandomVectors(5);
        List<vec> vec_b = GenerateRandomVectors(5);
        bool allTestsPassed = true;
        for (int i = 0; i<5 ; i++){
		vec v1 = vec_a[i] + vec_b[i];
		vec v2 = vec_b[i] + vec_a[i];
			if (!v1.approx(v2)){
				WriteLine($"A+B = B+A not true");
				allTestsPassed = false;
                        }
			vec v3 = vec_a[i] - vec_b[i];
                        vec v4 = vec_b[i] - vec_a[i];
                        if (!v3.approx(-v4)){
                                WriteLine($"A-B = -(B-A) not true");
                                allTestsPassed = false;
                        }

			vec v5 = 2*vec_a[i];
			vec v6 = vec_a[i]+vec_a[i];
			if (!v5.approx(v6)){
				WriteLine($"A+A = 2A not true");
				allTestsPassed = false;
                        }
			double v7 = vec.dot(vec_a[i],vec_a[i]);
                        double v8 = norm(vec_a[i])*norm(vec_a[i]);
                        if (!vec_a[i].approx_d(v7,v8)){
				WriteLine($"|A|^2 = A*A not true\n");
				allTestsPassed = false;
                        }
                }
		if (allTestsPassed)
        		{
            		WriteLine("All tests passed!");
        		}
        	else
        		{
            		WriteLine("All tests did not pass...");
        		}

                 return 0;
}//Main
}//main class
