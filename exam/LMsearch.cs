using System;
using static System.Math;
using static lagrangeroots;

public static class LMsearch{
    public static (vector,double) search(matrix A, double lambda){
        int n = A.size1;

            Func<vector, double ,vector> f = (a, b) =>{ //Trying to insert v^T*v-1 in function:
            vector V1 =  new vector(A*a-b*a); //The first equation i.e. A*v-lambda*v
            vector V = new vector(n+1);
            for(int i=0; i<n;i++) V[i] = V1[i]; //Setting all the values of V1 into the first n spots in V
            V[n] = a.dot(a)-1; //The second equation, i.e. v^T * v - 1
            return V;
            }; //Here a is the vector v, double b is lambda. 
            //So now we have a vector V, which contains all the equations which we would like to find roots for
        
        vector v = new vector(n);
        for(int i=0; i<n; i++) v[i] = 1; // Initial guess (not normalized)
        
        var LM = lagrangeroots.newton(A, f, v, lambda);
        return(LM);
    }
}