using System;
using static System.Console;
using static System.Math;

public class min{
    public static vector gradient(Func<vector,double>f, vector x){
    	vector g=new vector(x.size);
    	double fx=f(x);
        double eps=Pow(2,-26);
    	for(int i=0;i<x.size;i++){
	    	double dx=Abs(x[i])*eps;
	    	if(Abs(x[i])<Sqrt(eps)) dx=eps;
	    	x[i]+=dx;
	    	g[i]=(f(x)-fx)/dx;
	    	x[i]-=dx;
    	}
	    return g;
    }

    public static (vector,double) qnewton(Func<vector,double>f, vector x, double acc=1e-3){
	    double fx=f(x);
	    vector gx=gradient(f,x);
    	matrix B=matrix.id(x.size);
    	int nsteps=0;
        double eps=Pow(2,-26);
    	while(nsteps<10000){
	    	nsteps++;
	    	vector Dx=-B*gx;
	    	if(Dx.norm()<eps*x.norm()){
		    	Error.Write($"broyden: uups... |Dx|<DELTA*|x|\n");
			    break;
			}
	    	if(gx.norm()<acc){
		    	Error.Write($"broyden: job done: |gx|<acc\n");
			    break;
			}
	    	vector z;
		    double fz,lambda=1;
	    	while(true){// backtracking linesearch
		    	z=x+Dx*lambda;
	    		fz=f(z);
	    		if(fz<fx){
		    		break; // good step
				}
		    	if(lambda<eps){
			    	B.setid();
				    break; // accept anyway
				}
			lambda/=2;
	    	}
	    	vector s=z-x;
    		vector gz=gradient(f,z);
	    	vector y=gz-gx;
		    vector u=s-B*y;
    		double uTy=u%y;
	    	if(Abs(uTy)>1e-6){
		    	B.update(u,u,1/uTy); // SR1 update
	    	}
    		x=z;
	    	gx=gz;
		    fx=fz;
    	}
	    return (x,nsteps);
    }//qnewton

}//min