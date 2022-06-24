using System;
using static System.Console;
using static System.Math;

public class main{
    public static void Main(){
        Func<vector,double> f1 = x => Pow((1-x[0]),2)+100*Pow(x[1]-x[0]*x[0],2); 
        vector start1 = new vector(0.5,0.5);
        var (res1,steps1) = min.qnewton(f1,start1);

        WriteLine("Using routine on Rosenbrock's valley function: f(x,y) = (1-x)^2+100(y-x^2)^2");
        WriteLine($"Analytical result is (1,1). The result from the routine is (x,y)={(res1[0],res1[1])} found with N={steps1} steps");
        Write("\n\n");

        Func<vector,double> f2 = x => Pow((x[0]*x[0]+x[1]-11),2)+Pow(x[0]+x[1]*x[1]-7,2); 
        vector start2 = new vector(0.5,0.5);
        var (res2,steps2) = min.qnewton(f2,start2);
        WriteLine("Using routine on Himmelblau's function: f(x,y) = f(x,y)=(x^2+y-11)^2+(x+y^2-7)^2");
        WriteLine($"One of the analytical result is (3,2) (Others have a negative value of either x or y or both). \n The result from the routine is (x,y)={(res2[0],res2[1])} found with N={steps2} steps");
    }
}