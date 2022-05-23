using System;
using static System.Console;
using static System.Math;
using static matrix;
using static System.Random;
using static QRGS; 

class main{
    public static void Main(){
        int n = 5;
        int m = 5;
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

        Write("B matrix \n");
        var B = qrgs.inverse();
        B.print();

        Write("A*B=I \n");
        matrix check = A*B;
        check.print();
    }
}