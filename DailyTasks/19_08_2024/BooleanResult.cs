using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Enter the value for x: ");
		int x = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Enter the value for y: ");
		int y = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine($"The result of whether x is less than y is {x < y}");
		
	}	
}