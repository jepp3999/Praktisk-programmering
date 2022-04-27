using System;
using static System.Console;
using static System.Math;
using static cmath;

class main{
	static complex gamma(complex x){
	///single precision gamma function (Gergo Nemes, from Wikipedia)
		complex lngamma=x*log(x+1/(12*x-1/x/10))-x+log(2*PI/x)/2;
		return exp(lngamma);
	}

	public static void Main(){
		complex z;
		for(double x=-4.95;x<=5;x+=1.0/10){
			for(double y =-4.95;y<=5;y+=1.0/10){
				z = new complex(x,y);
				Write($"{x} {y} {abs(gamma(z))}\n");
			}
		}
	}
}
