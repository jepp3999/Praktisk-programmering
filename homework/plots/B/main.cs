using System;
using static System.Console;
using static System.Math;

class main{
	static double gamma(double x){
	///single precision gamma function (Gergo Nemes, from Wikipedia)
	if(x<0)return PI/Sin(PI*x)/gamma(1-x);
	if(x<9)return gamma(x+1)/x;
	double lngamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
	return Exp(lngamma);
	}


	static double lngamma(double x){
	///single precision gamma function (Gergo Nemes, from Wikipedia)
	if(x<0)return Double.NaN;
	if(x<9)return lngamma(x+1)-Log(x);
	double loggamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
	return loggamma;
	}

	public static void Main(){
		for(double x=-4.95;x<=5;x+=1.0/10){
			Write($"{x} {gamma(x)} {lngamma(x)}\n");
		}
	}
}
