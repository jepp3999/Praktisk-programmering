using System;
using static System.Console;
using static System.Math;

public class linspline{
	public static double linterp(double[] x, double[] y, double z){
        	int i=binsearch(x,z);
        	double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("dx less than zero");
        	double dy=y[i+1]-y[i];
	       	return y[i]+dy/dx*(z-x[i]);
        }


	public static int binsearch(double[] x, double z){/* locates the interval for z by bisection */ 
		if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
		int i=0, j=x.Length-1;
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>x[mid]) i=mid; else j=mid;
		}
		return i;
	}

	public static double linterpInteg(double[] x, double[] y, double z){
		double dx = 0;
		double dy = 0;
		double sum = 0;
		int i=binsearch(x,z);
		for(int j=0; j < i; j++){
	        	dx = x[j+1]-x[j];
			dy = y[j+1]-y[j];
			sum +=y[j]*dx+ (dy/dx) * dx*dx*0.5;
		}
		dx=x[i+1]-x[i];
		dy=y[i+1]-x[i];
	        sum += y[i]*(z-x[i]) + (dy/dx)*0.5*(z-x[i])*(z-x[i]);
		return sum;
	}
}


