using System;
using static System.Console;
using static System.Math;
using static System.Random;


class main{
    public static void Main(){
        int n = 3;
        int m = 3;
        matrix A = new matrix(n,m);
        matrix V = new matrix(n,m);

        Random rnd = new Random();
        for(int i=0;i<n;i++){
            for(int j=0;j<m;j++){
                int random = rnd.Next(10);
                A[i,j]=random;
                A[j,i]=random;
            } //for j
        } //for i

        matrix D = A.copy();
        jacobi.cyclic(D,V);
        
        var 
    }
}