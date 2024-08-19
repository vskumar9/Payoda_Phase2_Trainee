using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Enter a Number: ");
		double number = Convert.ToDouble(Console.ReadLine());
		double square = FindSquare(number);
		double cube = FindCube(number);
		Console.WriteLine("Square of {0} is {1} \nCube of {0} is {2}",number, square, cube);
	}
	
	static double FindSquare(double val){
		return val*val;
	}
	
	static double FindCube(double val){
		return val*val*val;
	}
	
}