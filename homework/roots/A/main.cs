using System;
using static System.Console;
using static System.Math;
using static vector;
using static QRGS;


public class main{
    public static void Main(){
        Func<vector,vector> f = x => new vector(2+ x[0]+x[0]*Pow(2,x[0])); //f(x) = 2 + x + x*2^x
        vector start = new vector(-1.2);
        var res = roots.newton(f,start);
        WriteLine("Testing that routine works for f(x) = 2 + x + x*2^x");
        WriteLine($"Analytical results is app. -1.46935. The result from the routine is x={res[0]}");

            Write("\n\n"); //Solving Rosenbrock's valley function: f(x,y) = (1-x)^2+100(y-x^2)^2

        Func<vector,vector> f1 = y => new vector(Pow((1-y[0]),2),100*Pow(y[1]-y[0]*y[0],2)); 
        vector start1 = new vector(0.5,0.5);
        var res1 = roots.newton(f1,start1);
        WriteLine("Using routine on Rosenbrock's valley function: f(x,y) = (1-x)^2+100(y-x^2)^2");
        WriteLine($"Analytical results is (1,1). The result from the routine is (x,y)={(res1[0],res1[1])}");
    }
}