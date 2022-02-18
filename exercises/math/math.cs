using static System.Console;
using static System.Math;

public static class math{
	public static void sqrt2(){
		double sqrt2 = Sqrt(2.0);
		Write($"sqrt(2) = {sqrt2}\n");
		Write($"sqrt2*sqrt2 = {sqrt2*sqrt2} (should be equal to 2) \n");
	}
	public static void expPi(){
		double expPi = Exp(PI);
		Write($"exp(pi) = {expPi} \n");
		Write($"ln(exp(pi)) = {Log(expPi)} (should be equal to pi) \n");
	}
	public static void Piexp(){
		double Piexp = Pow(PI,E);
		Write($"pow(pi,e) = {Piexp} \n");
		Write($"log(pow(pi,e),pi) = {Log(Piexp,PI)} (should be equal to e) \n");
	}
}


