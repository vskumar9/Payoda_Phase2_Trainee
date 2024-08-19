using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Enter your name: ");
		string name = Console.ReadLine();
		Console.WriteLine("Enter your age: ");
		int age = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Enter your country: ");
		string country = Console.ReadLine();
		Console.WriteLine("Welcome {0}. Your age is {1} and you are from {2}", name,age, country);
	}
	
}