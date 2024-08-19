using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Enter the number of pizzas bought: ");
		int pizza = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Enter the number of puffs bought: ");
		int puffs = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Enter the number of pepsi bought: ");
		int pepsi = Convert.ToInt32(Console.ReadLine());
		int pizzaAmount = pizza * 200;
		int puffsAmount = puffs * 40;
		int pepsiAmount = pepsi * 120;
		int total = pizzaAmount + puffsAmount + pepsiAmount;
		Console.WriteLine($"Cost of Pizzas: {pizzaAmount}\n" +
						  $"Cost of Puffs: {puffsAmount}\n" +
						 $"Cost of Pepsi: {pepsiAmount}\n" +
						 $"GST 12%: {total * 0.12}\n" +
						 $"CESS 5%: {total * 0.05}\n" +
						 $"Total Price: {total}");
		
	}	
}