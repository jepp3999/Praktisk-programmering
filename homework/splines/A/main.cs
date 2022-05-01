using System;
using static System.Console;
using static System.Math;



class main{
	public static void Main(){
		int N=5;
		int div=3;
		double step = 1.0/div;
		double[] xtable = new double[N*div];
		double[] ytable = new double[N*div];
		double[] yinteg = new double[N*div];
		int k=0;
		for(double i=0.0; i<N; i+=step){
			xtable[k] = i;
			ytable[k] = Cos(i);
			yinteg[k] = Sin(i);
			Write($"{xtable[k]} {ytable[k]} {yinteg[k]}\n");
			k++;
		}
		Write("\n\n"); //This is to create a new index in output file
		for(double z=0.0; z<xtable[xtable.Length-1]; z+=step/2){
		double linterp = linspline.linterp(xtable,ytable,z);
		double linterpInteg = linspline.linterpInteg(xtable,ytable,z);
		Write($"{z} {linterp} {linterpInteg}\n");
		}
	}
}
