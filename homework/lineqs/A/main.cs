using System;
using static System.Console;
using static System.Math;
using static matrix;
using static System.Random;
using static QRGS; 

class main{
    public static void Main(){
        int n = 9;
        int m = 2;
        matrix A = new matrix(n,m);
        Random rnd = new Random();
        for(int i=0;i<n;i++){
            for(int j=0;j<m;j++){
                int random = rnd.Next(10);
                A[i,j]=random;
            } //for j
        } //for i
        QRGS qrgs = new QRGS(A);
        matrix R = qrgs.R;
        matrix Q = qrgs.Q;

        Write("A matrix \n");
        A.print();
        Write("Q matrix \n");
        Q.print();
        Write("R matrix \n");
        R.print();
        Write("Q^T*Q");        
        matrix QTQ=Q.transpose()*Q;
        QTQ.print();
        Write("Q*R-A=0");        
        matrix Null=Q*R-A;
        Null.print();

        var b = new vector(n);
        for(int i=0;i<n;i++){
            b[i] = rnd.Next(15);
        } //for i

        Write("b vector \n");
        b.print();

        Write("x vector \n");
        var x = qrgs.solve(b);
        x.print();

        Write("A*x-b \n");
        vector check = A*x-b;
        check.print();
    }
}}