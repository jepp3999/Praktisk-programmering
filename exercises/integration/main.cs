using System;
using static System.Console;
using static System.Math;
using static integrate;

class main{
	public static void integration(){
	Func<double,double> f = delegate(double x){return Log(x)/Sqrt(x);};
	double result = quad(f,0,1);
	Write($"Result = {result}\n");
	}

	static double erf(double z){
		Func<double,double> f = delegate(double x){return Exp(-x*x);};
		return 2/Sqrt(PI)*quad(f,0,z);
	}

	public static void Main(){
		for(double x=-3.0 ; x<=3.0 ; x+=1.0/8){
			Write($"{x} {erf(x)}\n");
		}
	}
}

