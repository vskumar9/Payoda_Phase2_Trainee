using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		List<Product> list = new List<Product>();
		list.Add(new Product("Apple", "Prod1234", DateTime.Now, 200));
		list.Add(new Product("Hair Trimmer", "Prod1276", DateTime.Now, 1200));
		list.Add(new Product("Steel Box", "Prod1209", DateTime.Now, 400));
		list.Add(new Product("Rope", "Prod1213", DateTime.Now, 99));
		list.Add(new Product("Chair", "Prod1342", DateTime.Now, 309));
		
		Console.WriteLine(String.Format("{0,-15}{1,-15}{2,-25}{3,-15}", "Product Name", "Serial Number","Purchase Date", "Purchase Cost"));
		list.ForEach( a => Console.WriteLine(a));
		
		
		
	}
}

class Product
{
	string _productName;
	string _serialNumber;
	DateTime _purchaseDate;
	double _cost;
	
	public Product(string productName, string serialNumber, DateTime purchaseDate, double cost)
	{
		_productName = productName;
		_serialNumber = serialNumber;
		_purchaseDate = purchaseDate;
		_cost = cost;
	}
	
	public override string ToString()
	{
		return String.Format("{0,-15}{1,-15}{2,-25}{3,-15}", _productName, _serialNumber, _purchaseDate.ToString(@"yyyy:mm:dd"), _cost);
	}
	
}