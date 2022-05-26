using System;
using static System.Console;
using static System.Math;

public class main{
    public static void Main(){
        Func<double,double> f1 = x => Sqrt(x);
        Func<double,double> f2 = x => 1/Sqrt(x);
        Func<double,double> f3 = x => 4*Sqrt(1-x*x);
        Func<double,double> f4 = x => Log(x)/Sqrt(x);

        double a = 0;
        double b = 1;
        
        var F1 = quadratures.integrate(f1,a,b);
        var F2 = quadratures.integrate(f2,a,b);
        var F3 = quadratures.integrate(f3,a,b);
        var F4 = quadratures.integrate(f4,a,b);

        WriteLine($"Integrating functions from 0 to 1:");
        WriteLine($"f1(x) = sqrt(x), equal to 2/3. Result is {F1} ");
        WriteLine($"f2(x) = 1/sqrt(x), equal to 2. Result is {F2} ");
        WriteLine($"f3(x) = 4*sqrt(1-x^2), equal to pi. Result is {F3} ");
        WriteLine($"f4(x) = ln(x)/sqrt(x), equal to -4. Result is {F4} ");

        using(var outfile = new System.IO.StreamWriter("Data.txt")){
            for(double z = -3; z<=3; z+=0.1){
                outfile.WriteLine($"{z} {quadratures.erf(z)}");
            }
        }
    }
}