using System;
using static System.Console;


public class QRGS{
	public matrix Q,R;
	public int m,n;
	public QRGS(matrix A){/* run the Gram-Schmidt process */
		n=A.size1;
		m=A.size2;
		Q=A.copy();
		R=new matrix(m,m);
		for(int i =0; i<m; i++){
			R[i,i]=Q[i].norm();
			Q[i]=Q[i]/R[i,i];
			for(int j=i+1; j<m; j++){
				R[i,j]=Q[i].dot(Q[j]);
				Q[j]=Q[j] - R[i,j]*Q[i];
			}
		} //Input matrix A get matrix Q and R out

	}
	public vector solve(vector b){
		var y = Q.transpose()*b;
		int k = y.size;
		vector x = new vector(k);
		x[k-1] = y[k-1]/R[k-1,k-1];

		for(int i = k-2;i>=0;i--){
			double sum=0;
			for(int j=i+1;j<k;j++){
				sum += R[i,j]*x[j];
			}
			x[i] = (y[i]-sum)/R[i,i];
		}
	return x;
	}
	//public matrix inverse(){/* return the inverse matrix (part B) */}
	//public double determinant(){/* return ΠiRii */}
}