using static System.Console;
using static System.Math;

public class vec{
	public double x,y,z;
	//constructors:
	public vec(){x=y=z=0;}
	public vec(double a, double b, double c){
		x=a;y=b;z=c;
		}
	//print method
	public void print(string s){
		Write(s);WriteLine($"{x} {y} {z}");
		}
	public void print(){this.print("");}

	public static void print(vec v){v.print("static method:");}

	//operators:
	public static vec operator*(vec v, double c){return new vec(c*v.x,c*v.y,c*v.z);}
	public static vec operator*(double c, vec v){return v*c;}
	public static vec operator+(vec u, vec v){return new vec(u.x+v.x,u.y+v.y,u.z+v.z);}
	public static vec operator+(vec u){return u;}
	public static vec operator-(vec u, vec v){return new vec(u.x-v.x,u.y-v.y,u.z-v.z);}
	public static vec operator-(vec u){return -1*u;}

public double dot(vec other){return this.x*other.x+this.y*other.y+this.z*other.z;}
public static double dot(vec v, vec w){return v.x*w.x+v.y*w.y+v.z*w.z;}

static bool approx(double a,double b,double tau=1e-9,double eps=1e-9){
	if(Abs(a-b)<tau)return true;
	if(Abs(a-b)/(Abs(a)+Abs(b))<eps)return true;
	return false;
	}
public bool approx(vec other){
	if(!approx(this.x,other.x))return false;
	if(!approx(this.y,other.y))return false;
	if(!approx(this.z,other.z))return false;
	return true;
	}
public static bool approx(vec u, vec v){return u.approx(v); }

}
