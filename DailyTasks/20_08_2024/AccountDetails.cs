using System;
					
public class Program
{
	public static void Main()
	{
		Console.Write("Enter account id: ");
		int id = Convert.ToInt32(Console.ReadLine());
		Console.Write("Enter account type: ");
		string type = Console.ReadLine();
		Console.Write("Enter account balance: ");
		Double balance = Convert.ToDouble(Console.ReadLine());
		Console.Write("Enter amount to withdraw: ");
		Double withDraw = Convert.ToDouble(Console.ReadLine());
		Account acc = new Account(id, type, balance);
		Console.Write(acc.GetDetails());
		if(acc.WithDraw(withDraw))
		{
			Console.WriteLine($"New Balance: {acc.AccBalance - withDraw}");
		}
		else
		{
			Console.WriteLine("Insufficient balance");
		}
		
										 
		
	}
}

class Account
{
	int id;
	string accountType;
	double balance;
	
	public Account()
	{
		id = 0;
		accountType = null;
		balance = 0D;
	}
	
	public Account(int id, string accountType, double balance)
	{
		this.id = id;
		this.accountType = accountType;
		this.balance = balance;
	}
	
	public int AccId
	{
		set
		{
			id = value;
		}
		get
		{
			return id;
		}	
	}
	
	public string accAccountType
	{
		set
		{
			accountType = value;
		}
		get
		{
			return accountType;
		}	
	}
	
	public double AccBalance
	{
		set
		{
			balance = value;
		}
		get
		{
			return balance;
		}	
	}
	
	public Boolean WithDraw(double amount)
	{
		return amount < balance;
	}
	
	public string GetDetails()
	{
		return $"Account Id: {id}\n" + 
			$"Account Type: {accountType}\n" +
			$"Balance: {balance}\n";
	}
		
		
}
