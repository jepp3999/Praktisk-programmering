using System;
using static System.Console;
using static System.Math;
using static qspline;

class main{
	public static void Main(){
		double a=0,b=10;
		int N=30;
		double step = (b-a)/(N-1);
		double[] xtable = new double[N];
		double[] ytable = new double[N];
		double[] yderiv = new double[N];
		double[] yinteg = new double[N];
		for(int i=0; i<N; i++){
			xtable[i] = a+i*step;
//			ytable[i] = Pow(xtable[i],2)/2;
//			yderiv[i] = xtable[i];
//			yinteg[i] = Pow(xtable[i],3)/6;
			ytable[i] = Cos(xtable[i]);
			yderiv[i] = -Sin(xtable[i]);
			yinteg[i] = Sin(xtable[i]);
			Write($"{xtable[i]} {ytable[i]} {yderiv[i]} {yinteg[i]}\n");
		}
		Write("\n\n"); //This is to create a new index in output file
		qspline s = new qspline(xtable,ytable);
		for(double z=0.0; z<xtable[xtable.Length-1]; z+=step/64){
			//double qinterpInteg = linspline.linterpInteg(xtable,ytable,z);
			Write($"{z} {s.eval(z)} {s.derivative(z)} {s.integ(z)}\n");
		}
	}
}
