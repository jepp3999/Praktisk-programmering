using System;
using static System.Console;
using static System.Math;
using static vector;
using static QRGS;

public class lagrangeroots{
    public static matrix Jacobian(matrix A, vector v, double lambda){
	    int n=v.size;

        matrix J = new matrix(n+1,n+1); //Calculate Jacobian for function f w.r.t. [v,lambda]
        int d=1;
        for(int i=0; i<n; i++){
            for(int j = 0; j<n; j++){
                if(i==j) d=1; // delta function
                else d=0;
                J[i,j] = A[i,j] - lambda*d; //First part of function derivative w.r.t. v
            } 
            // for j
            J[i,n] = -v[i]; //first part of function (i.e. A*v-lambda*v) derivative w.r.t. lambda
            J[n,i] = 2*v[i]; //second part of function (i.e. v^T*v-1) derivative w.r.t. v
        }// for i
        J[n,n] = 0; //second part of function derivative w.r.t. lambda

        return J;
    }
    
    public static (vector,double) newton(matrix A, Func<vector,double,vector> f,vector v, double lambda, double eps=1e-2){
	    int n=v.size; //Just the roots finding mechanism from the homework.
            //albeit a bit modified.

        vector fvl = f(v,lambda);
        vector z, fz;
        double lambda2;

	    while(true){
            matrix J=Jacobian(A,v,lambda);
	    	var qrgs=new QRGS(J);
	    	vector Dx=qrgs.solve(-fvl); 

            vector dx = new vector(n);
            for(int k=0; k<n;k++) dx[k] = Dx[k];

            double dlambda = Dx[n];

	    	double s=1;
	    	while(true){// backtracking linesearch
		    	z=v+dx*s;
                lambda2 = lambda + dlambda;
		    	fz=f(z, lambda2);
		    	if(fz.norm()<(1-s/2)*fvl.norm()){ break; }
	    		if(s<1.0/64){ break; }
	    		s/=2;
	    	}
	    	v=z;
            lambda = lambda2;
	    	fvl=fz;
	    	if(fvl.norm()<eps)break;
    	}
    return (v,lambda);
    }
}