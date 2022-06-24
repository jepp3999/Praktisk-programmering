using System;
using static System.Console;
using static System.Math;
using static vector;
using static QRGS;

public class roots{
    public static matrix Jacobian(Func<vector,vector> f,vector x, vector fx=null,vector dx=null){
	    int n=x.size;
        double delta = Pow(2,-26);
    	if(dx==null) dx = x.map(t => Abs(t)*delta);
    	matrix J=new matrix(n,n);
    	if(fx == null)fx=f(x);
    	for(int j=0;j<n;j++){
    		x[j]+=dx[j];
    		vector df=f(x)-fx;
    		for(int i=0;i<n;i++) J[i,j]=df[i]/dx[j];
    		x[j]-=dx[j];
    	}
	return J;
    }
    
    public static vector newton(Func<vector,vector> f, vector x, double eps=1e-2){
	    int n=x.size;
	    vector fx=f(x),z,fz; //define f(x), z and fz as vectors
        vector dx = null;
        
	    while(true){
            matrix J=Jacobian(f,x,fx,dx);
	    	var qrgs=new QRGS(J);
	    	vector Dx=qrgs.solve(-fx);
	    	double s=1;
	    	while(true){// backtracking linesearch
		    	z=x+Dx*s;
		    	fz=f(z);
		    	if(fz.norm()<(1-s/2)*fx.norm()){ break; }
	    		if(s<1.0/64){ break; }
	    		s/=2;
	    	}
	    	x=z;
	    	fx=fz;
	    	if(fx.norm()<eps)break;
    	}
	return x;
    }
}