using System;
using static System.Console;
using static System.Math;



class main{
	public static void Main(){
		double a=0,b=10;
		int N=10;
		double step = (b-a)/(N-1);
		double[] xtable = new double[N];
		double[] ytable = new double[N];
		double[] yinteg = new double[N];
		for(int i=0; i<N; i++){
			xtable[i] = a+i*step;
			ytable[i] = xtable[i];
			yinteg[i] = Pow(xtable[i],2)/2;
			Write($"{xtable[i]} {ytable[i]} {yinteg[i]}\n");
		}
		Write("\n\n"); //This is to create a new index in output file
		for(double z=0.0; z<xtable[xtable.Length-1]; z+=step/64){
			double linterp = linspline.linterp(xtable,ytable,z);
			double linterpInteg = linspline.linterpInteg(xtable,ytable,z);
			Write($"{z} {linterp} {linterpInteg-1}\n");
		}
	}
}
