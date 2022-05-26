using System;
using static System.Console;
using static System.Math;
using static ode;

class main{ //taken from the exercise 'odeint'
	public static void Main(){
		double b=0.25, c=5;
		Func<double,vector,vector> F = delegate(double x, vector y){
			double theta=y[0], omega=y[1];
			return new vector(omega,-b*omega-c*Sin(theta));
		};

		double init=0.0;
		double end=10.0;
		vector ystart = new vector(PI-0.1,0.1);
        vector yend = ode.driver(F,init,ystart,end);

	}
}   

