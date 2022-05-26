using System;
using static System.Console;

public class lsfit{
    int n,m;
    public vector c;
    public matrix A;
    public lsfit(Func<double,double>[] f, vector x, vector y, vector dy){
        n = x.size;
        m = f.Length;
        A = new matrix(n,m);
        vector b = new vector(n);
        for(int i=0; i<n; i++){
            b[i]=y[i]/dy[i];
            for(int k=0; k<m; k++){
                A[i,k] = f[k](x[i])/dy[i];
            }
        }
        var qrgs = new QRGS(A);
        c = qrgs.solve(b);
    }
    
    public matrix Cov(matrix A){
        matrix ATA = A.transpose()*A;
        var qrgs = new QRGS(ATA);
        var cov = qrgs.inverse();
        return cov;
    }
}