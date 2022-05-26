using System;
using static System.Console;
using static System.Math;
using static matrix;
using static vector;
using static System.Random;

class main{
    public static void Main(){
        int n = 5;
        int m = 5;
        matrix A = new matrix(n,m);
        matrix V = new matrix(n,m);
        matrix I = new matrix(n,m);
        I.set_identity();
        Random rnd = new Random();
        for(int i=0;i<n;i++){
            for(int j=0;j<m;j++){
                int random = rnd.Next(10);
                A[i,j]=random;
                A[j,i]=random;
            } //for j
        } //for i

        A.print("Random symmetric matrix A = ");
        matrix D = A.copy();

        Jacobi.Cyclic(D,V);
        D.print("\n D=");
        V.print("\n V=");

        Write("Checking that the eigenvalue-decomposition works:\n");
        
        WriteLine($"A = V D V^T {A.approx(V*D*V.transpose())}");
        WriteLine($"D = V^T A V {D.approx(V.transpose()*A*V)}");
        WriteLine($"I = V^T V {I.approx(V.transpose()*V)}");
        WriteLine($"I = V V^T {I.approx(V*V.transpose())}");
    }
}
