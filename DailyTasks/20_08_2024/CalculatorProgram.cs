using System;
					
public class Program
{
	public static void Main()
	{
		Console.Write("Enter the operator: ");
		char op = Convert.ToChar(Console.ReadLine());
		Console.Write("Enter the operands: ");
		int a = Convert.ToInt32(Console.ReadLine());
		int b = Convert.ToInt32(Console.ReadLine());
		Claculator cal = new Claculator();
		switch(op)
		{
			case '+':
				Console.WriteLine($"Result of {a} {op} {b} is {cal.Addition(a, b)}");
				break;
			case '-':
				Console.WriteLine($"Result of {a} {op} {b} is {cal.Subtraction(a, b)}");
				break;
			case '*':
				Console.WriteLine($"Result of {a} {op} {b} is {cal.Multipllication(a, b)}");
				break;
			case '/':
				double c;
				Console.WriteLine($"Result of {a} {op} {b} is {cal.Division(a, b, out c)}");
				Console.WriteLine($"Remainder = {c}");
				break;
			default:
				Console.WriteLine("Invalid Operator");
				break;
		}
	}
}

class Claculator
{
	public int Addition(int a, int b)
	{
		return a + b;
	}
	public int Subtraction(int a, int b)
	{
		return a - b;
	}
	public int Multipllication(int a, int b)
	{
		return a * b;
	}
	public double Division(int a, int b, out double remainder)
	{
		remainder = a % b;
		return a / b;
	}
}
