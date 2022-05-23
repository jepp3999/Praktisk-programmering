using System;
using static System.Console;
using static System.Math;

public class cspline{
	public double[] x, y, p, c, dx, dy, b, d;
	public cspline(double[] xs, double[] ys){
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
		d = new double [n-1];
		var D = new double[n];
		var Q = new double[n-1];
		var B = new double[n];

		for(int k=0; k<n-1; k++){
			dx[k] = x[k+1]-x[k];
			p[k] = (y[k+1]-y[k])/dx[k];
		}
		D[0]=2; Q[0]=1; B[0]=3*p[0]; D[n-1]=2; B[n-1]=3*p[n-2];
		for(int i=0;i<n-2;i++){
   			D[i+1]=2*dx[i]/dx[i+1]+2;
   			Q[i+1]=dx[i]/dx[i+1];
   			B[i+1]=3*(p[i]+p[i+1]*dx[i]/dx[i+1]);
		}

		for(int i=1;i<n;i++){
			D[i]-=Q[i-1]/D[i-1];
			B[i]-=B[i-1]/D[i-1];
		}

		b[n-1]=B[n-1]/D[n-1];
		for(int i=n-2;i>=0;i--){
			b[i]=(B[i]-Q[i]*b[i+1])/D[i];
		}

		for(int i=0;i<n-1;i++){
	   		c[i]=(-2*b[i]-b[i+1]+3*p[i])/dx[i];
	   		d[i]=(b[i]+b[i+1]-2*p[i])/dx[i]/dx[i];
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
