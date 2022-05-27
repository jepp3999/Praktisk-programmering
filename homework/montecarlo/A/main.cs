using System;
using static System.Console;
using static System.Math;
using static vector;
using static montecarlo;

public class main{
    public static void Main(){
        Func<vector,double> f = x => x[0]*x[0] + x[1]; //test function
        vector a = new vector(0,0);
        vector b = new vector(5,5);
        int N = 1000000;
        
        var intf = montecarlo.plainmc(f,a,b,N);

        WriteLine($"The integral of x^2+y from (0,0) to (5,5) using {N} points\n gives {intf.Item1} with an error of {intf.Item2}.");
        WriteLine($"The result should be 1625/6 app. equal to 270.83.");
        Write("\n\n");

        Func<vector,double> f1 = x => 1/(1-Cos(x[0])*Cos(x[1])*Cos(x[2]))/(PI*PI*PI); //
        vector a1 = new vector(0,0,0);
        vector b1 = new vector(PI,PI,PI);
        int N1 = 10000000;
        
        var intf1 = montecarlo.plainmc(f1,a1,b1,N1);

        WriteLine($"The integral of 1/(1-cos(x)*cos(y)*cos(z))/(pi^3) from (0,0,0) to (pi,pi,pi) using {N1} points\n gives {intf1.Item1} with an error of {intf1.Item2}.");
        WriteLine($"The result should be app. equal to 1.3932039296856768591842462603255");
    }


}