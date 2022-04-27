using System;
using static System.Console;
using static System.Math;
using static integrate;

class main{
        public static void Main(){
        Func<double,double> f = delegate(double x){return Log(x)/Sqrt(x);};
        double result = quad(f,0,1);
        Write($"Result = {result}\n");
        }
}
