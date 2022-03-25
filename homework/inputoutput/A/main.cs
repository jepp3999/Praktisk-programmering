using System;
using System.IO;
using static System.Console;
using static System.Math;

class main{
	static public void Main(){
		char[] delimiters = {' ','\t','\n'};
		var options = StringSplitOptions.RemoveEmptyEntries;
		for( string line = ReadLine(); line != null; line = ReadLine() ){
			var words = line.Split(delimiters,options);
			foreach(var word in words){
				double x = double.Parse(word);
				WriteLine($"x={x} sin(x)={Sin(x)} cos(x)={Cos(x)}");
                	}
        	}
	}
}

