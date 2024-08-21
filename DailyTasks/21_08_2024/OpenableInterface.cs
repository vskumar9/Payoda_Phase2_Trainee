using System;
					
public class Program
{
	public static void Main()
	{
		Console.Write("Wnter the letter found in the paper: ");
		char letter = Convert.ToChar(Console.ReadLine());
		switch(letter)
		{
			case 'T' :
				IOpenable treasure = new TreasureBox();
				Console.WriteLine(treasure.OpenSesame());
				break;
			case 'P' :
				IOpenable parchute = new Parachute();
				Console.WriteLine(parchute.OpenSesame());
				break;
		}
	}
}

interface IOpenable
{
	string OpenSesame();
}

class TreasureBox : IOpenable
{
	public string OpenSesame()
	{
		return "Congratulations, Here is your lucky win";
	}
}

class Parachute : IOpenable
{
	public string OpenSesame()
	{
		return "Have a thrilling experience flying in air";
	}
}



