using System;
using static System.Console;
using static System.Math;

public class ode{
    public static (vector,vector) rkstep12(
	Func<double,vector,vector> f, /* the f from dy/dx=f(x,y) */
	double x,   /* the current value of the variable */
	vector y,   /* the current value y(x) of the sought function */
	double h    /* the step to be taken */
    ){ // Runge-Kutta Euler/Midpoint method (probably not the most effective)
    	vector k0 = f(x,y); /* embedded lower order formula (Euler) */
	    vector k1 = f(x+h/2,y+k0*(h/2)); /* higher order formula (midpoint) */
    	vector yh = y+k1*h;     /* y(x+h) estimate */
	    vector er = (k1-k0)*h;  /* error estimate */
	    return (yh,er);
    }

    public static vector driver(
    Func<double,vector,vector> f, /* the f from dy/dx=f(x,y) */
   	double a,                     /* the start-point a */
   	vector ya,                    /* y(a) */
   	double b,                     /* the end-point of the integration */
   	double h=0.01,                  /* initial step-size */
   	double acc=0.01,              /* absolute accuracy goal */
	double eps=0.01               /* relative accuracy goal */
    ){
        if(a>b) throw new Exception("driver: a>b");
        double x=a; vector y=ya;
        do {
            if(x>=b) return y; /* job done */
            if(x+h>b) h=b-x;   /* last step should end at b */

            var (yh,erv) = rkstep12(f,x,y,h);
            double tol = Max(acc,yh.norm()*eps) * Sqrt(h/(b-a));
            double err = erv.norm();
            if(err<=tol){ x+=h; y=yh; Error.Write($"{x} {y[0]} {y[1]}\n");} // accept step
        	h *= Min( Pow(tol/err,0.25)*0.95 , 2); // readjust stepsize
        }while(true);
    }//driver
}
    