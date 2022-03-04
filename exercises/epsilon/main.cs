using System;
using static System.Console;
using static System.Math;

static public class epsilon{
	static void Main(){
	int i=1;
	while(i+1>i) {i++;}{
		Write("my max int = {0}\n",i);
		Write($"Max int from int.Maxvalue is {int.MaxValue}\n");
		}
	int j=-1;
	while(j-1<i) {j++;}{
		Write("my min int = {0}\n",j);
		Write($"Min int from int.Minvalue is {int.MinValue}\n");
		}
	double x=1; while(1+x!=1){x/=2;} x*=2;
	float y=1F; while((float)(1F+y) != 1F){y/=2F;} y*=2F;
		Write($"My value of epsilon from double is {x}\n");
		Write($"This is app. {System.Math.Pow(2,-52)}\n");
		Write($"My value of epsilon from float is {y}\n");
		Write($"This is app. {System.Math.Pow(2,-23)}\n");

	int n=(int)1e6;
	double epsilon=Pow(2,-52);
	double tiny=epsilon/2;
	double sumA=0,sumB=0;

	sumA+=1; for(int k=0;k<n;k++){sumA+=tiny;}
	WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}");

	for(int l=0;l<n;l++){sumB+=tiny;} sumB+=1; 
	WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}"); 
	}

	public static bool approx(double a, double b, double tau=1e-9, double epsilon=1e-9){
		if (Abs(a-b)<tau) 
			return true;
		else if (Abs(a-b)/(Abs(a)+Abs(b))<epsilon) 
			return true;
		else 
			return false;
	}
}
