using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static ode;

class main{
	public static void Main(){
		double b=0.25, c=5;
		Func<double,vector,vector> F = delegate(double t, vector y){
			double theta=y[0], omega=y[1];
			return new vector(omega,-b*omega-c*Sin(theta));
		};

		double init=0;
		double end=10;
		vector ystart = new vector(PI-0.1,0.1);
		var xlist = new List<double>();
		var ylist = new List<vector>();
		vector ystop = ivp(F,init,ystart,end,xlist,ylist);

		for(int i=0; i<xlist.Count;i++){
			Write($"{xlist[i]} {ylist[i][0]} {ylist[i][1]}\n");
		}
	}
}
