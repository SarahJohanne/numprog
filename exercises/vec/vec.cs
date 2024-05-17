using static System.Console;
using static System.Math;
public class vec{
	public double x,y,z;
	//constructors:
	public vec(){ x=y=z=0;}
	public vec(double x, double y, double z){
		this.x=x;
		this.y=y;
		this.z=z;
}
	//operators:
	public static vec operator*(vec v, double c){return new vec(c*v.x,c*v.y,c*v.z);}
	public static vec operator*(double c, vec v){return v*c;}
	public static vec operator+(vec u, vec v){return new vec(u.x+v.x, u.y+v.y, u.z+v.z);}
	public static vec operator-(vec u){return new vec(-u.x,-u.y,-u.z);}
	public static vec operator-(vec u, vec v){return new vec(u.x-v.x, u.y-v.y, u.z-v.z);}	
	//methods:
	public void print(string s){Write(s);
		WriteLine($"{x} {y} {z}");
	}
	public void print(){this.print("");
	}
	public double dot(vec other) => this.x*other.x+this.y*other.y+this.z*other.z; /* her kalder man den som u.dot(v)*/
	public static double dot(vec v, vec w){return v.x*w.x+v.y*w.y+v.z*w.z;} /*Her kalder man den som vec.dot(u,v)*/
	public static double norm(vec u){
		return Sqrt(Pow(u.x,2)+Pow(u.y,2)+Pow(u.z,2));}

	public bool approx_d(double a,double b,double acc=1e-9,double eps=1e-9){
		if(Abs(a-b)<acc)return true;
		if(Abs(a-b)<(Abs(a)+Abs(b))*eps)return true;
		return false;
	}

	static bool approx(double a, double b, double acc=1e-9, double eps=1e-9){
		if(Abs(a-b)<acc) return true;
		if(Abs(a-b)<(Abs(a)+Abs(b))*eps)return true;
		return false;
	}
	public bool approx(vec other){
		if(!approx(this.x, other.x))return false;/*Siger bare, at hvis funktionen fra før giver true sættes det som false, og operationen med at returnere false sker altså ikke. Gav approx fra før i stedet false ville den blive true, og her derfor aktivere operationen, som ville være at returnere et false.*/
		if(!approx(this.y, other.y))return false;
		if(!approx(this.z, other.z))return false;
		return true;
		}
	public static bool approx(vec u, vec v)=>u.approx(v);/*returnerer outputtet fra funktionen før - dvs giver os det endelige resultat: er de to vektorer approximativt ens?*/
	
	public override string ToString(){ return $"{x} {y} {z}";}/*overrider den normale ToString method, der normalt skriver en type ud som streng. Det her er en custom class, så vi redifinerer og beder den om at skrive vektorkoordinater ud når den kaldes.*/
	
	





}

