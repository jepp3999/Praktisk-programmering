using System;
using static System.Console;
using static System.Math;


class main{
    public static void Main(){
        vector x = new vector(new double[] {1,2,3,4,6,9,10,13,15}); //Time t
        vector y = new vector(new double[] {117,100,88,72,53,29.5,25.2,15.2,11.1}); //Activity
        vector dy = new vector(new double[]  {5,5,5,5,5,5,1,1,1,1}); //Uncertainty
        var f = new Func<double,double>[] {z => 1.0, z => z};
        
        for(int i=0; i<x.size; i++){
            Write($"x={x[i]} y={y[i]} dy={dy[i]} \n");
        }
        Write("\n\n");
        for(int j=0; j<x.size; j++){
            dy[j] = dy[j]/y[j];
            y[j] = Log(y[j]);
            Write($"{x[j]} {y[j]} {dy[j]}\n");
        }
        Write("\n\n");

        var ls = new lsfit(f,x,y,dy);
        vector c = ls.c;
        Write("Fit coefficients:");
        c.print();

        Write("\n\n");
        double a=0, b=15;
        int N = 100;
        double step = (b-a)/(N-1);
        double[] xtable = new double[N];
		double[] ytable = new double[N];
        
        for(int i=0;i<N;i++){
            xtable[i] = a+i*step;
            ytable[i] = c[0]*f[0](xtable[i]) + c[1]*f[1](xtable[i]);
            Write($"{xtable[i]} {ytable[i]}\n");
        }
        
        Write("\n\n");
        double lambda = -c[1];
        double T = Log(2.0)/lambda;
        Write($"The half-time of ThX is {T} days. The real value is 3.6 days.");
    }
}