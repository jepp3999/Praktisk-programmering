using System;
using static System.Console;
using static System.Math;
using static table;

public static class main{
	public static void Main(){
	double k=1;
	System.Func<double,double> sinkx = delegate(double x){return Sin(k*x);};
	for(double i=1;i<=3;i++){
	k=i;
	Write($" k={k} sin(k*x)\n");
	make_table(sinkx,0,PI,PI/10);
	}
	}
}
