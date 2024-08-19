using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Value of number: ");
		SByte number = Convert.ToSByte(Console.ReadLine());
		Console.WriteLine($"Largest Value stored in a signed byte: {number}");
		
		
	}	
}