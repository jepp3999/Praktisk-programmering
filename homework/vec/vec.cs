using static System.Console;

public class vec{
	public double x,y,z;
	//constructors:
	public vec(double a, double b, double c){
		x=a;y=b;z=c;
		}
	public vec(){x=y=z=0;}
	//print method
	public void print(string s){
		Write(s);WriteLine($"{x} {y} {z}");
		}
	public void print(){this.print("");}
}
