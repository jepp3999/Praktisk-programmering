using System;
using static System.Console;
using static System.Math;

public class qspline{
	public double[] x, y, p, c, dx, dy, b;
	public qspline(double[] xs, double[] ys){
		int n = xs.Length;
		x = new double [n];
		y = new double [n];
		for(int i=0; i<n; i++){
			x[i] = xs[i];
			y[i] = ys[i];
		}
		dx = new double [n-1];
		dy = new double [n-1];
		p = new double [n-1];
		c = new double [n-1];
		b = new double [n-1];
		for(int k=0; k<n-1; k++){
			dx[k] = x[k+1]-x[k];
			p[k] = (y[k+1]-y[k])/dx[k];
		}

		c[0]=0;
		for(int j = 0; j<n-2 ;j++){
			c[j+1] = (p[j+1]-p[j] - c[j]*dx[j])/dx[j+1]; //recursion upwards
		}
		c[n-2]= c[n-2]/2;
		for(int h = n-3; h>=0; h--){
			c[h] = (p[h+1] - p[h] - c[h+1]*dx[h+1])/dx[h]; //recursion downwards
		}
		for(int i = 0; i<n-1; i++){
			b[i] = p[i] - c[i]*dx[i];
		}
	}

	public double eval(double z){
		int i = binsearch(x,z);
		return y[i] + b[i]*(z-x[i]) + c[i]*(z-x[i])*(z-x[i]);
	}

	public double derivative(double z){
		int i=binsearch(x,z);
		return b[i] + 2*c[i]*(z-x[i]);
	}

	public double integ(double z){
		int i = binsearch(x,z);
		double sum =0;
		for(int j = 0; j<i; j++){
			sum += y[j]*dx[j] + b[j]*dx[j]*dx[j]*0.5 +c[j]*dx[j]*dx[j]*dx[j]/3;
		}
		double dxi = (z-x[i]);
		sum += dxi*(y[i] + b[i]*dxi*0.5 + c[i]*dxi*dxi/3);
		return sum;
	}

	public static int binsearch(double[] x, double z){/* locates the interval for z by bisection */ 
		if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
		int i=0, j=x.Length-1;
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>x[mid]) i=mid;
			else j=mid;
		}
		return i;
	}
}
