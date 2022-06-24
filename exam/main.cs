using System;
using static System.Console;
using static System.Math;
using static System.Random;
using static vector;
using static QRGS;
using static LMsearch;

public class main{ //Random symmetric matric
    public static void Main(){
        int n = 6;
        matrix A = new matrix(n,n);
        Random rnd = new Random();
        for(int i=0; i<n; i++){
            for(int j=0; j<n; j++){
                int random = rnd.Next(10);
                A[i,j] = random;
                A[j,i] = random;
            }
        }

        double lambda = 1;
        var res = LMsearch.search(A,lambda);
        vector eigvec = res.Item1;
        double eigval = res.Item2;
        WriteLine($"I have made a random symmetric matrix A, which looks like:");
        A.print();
        WriteLine($"I apply the routine, where I have made use of Lagrange multiplier and an analytical Jacobian.");
        WriteLine($"The use of the Lagrange multiplier is due to the constraint that the eigenvector of the matrix should have unit length.");
        WriteLine($"I then use a slightly modified root search routine to find the following eigenvector and eigenvalue");
        WriteLine($"eigenvalue = {eigval}");
        eigvec.print("eigenvector =");
        WriteLine($"We need to check that the constraint actually worked, i.e. that the eigenvectors have unit length. So we take the dot-product");
        double dot = eigvec.dot(eigvec);
        WriteLine($"v^T v = {dot}");
        WriteLine($"We see that the dot product is approximately equal to 1. So the constraint is forfilled");        
    }
}