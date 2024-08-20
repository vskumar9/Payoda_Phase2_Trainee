using System;

					
public class Program
{
	public static void Main()
	{
		Console.Write("Enter a game: ");
		string game1 = Console.ReadLine();
		Console.Write("Enter the maximum number of players: ");
		int maxNumPlayers1 = Convert.ToInt32(Console.ReadLine());
		Console.Write("Enter a game that has time limit: ");
		string game2 = Console.ReadLine();
		Console.Write("Enter the maximum number of players: ");
		int maxNumPlayers2 = Convert.ToInt32(Console.ReadLine());
		Console.Write("Enter the time limit in minutes: ");
		int timeLimit = Convert.ToInt32(Console.ReadLine());
		
		Game game = new Game(){Name = game1, MaxNumPlayers = maxNumPlayers1};
		GameWithTimeLimit gwtl = new GameWithTimeLimit(){Name = game2, MaxNumPlayers = maxNumPlayers2, TimeLimit = timeLimit};
		Console.WriteLine(game.ToString());
		Console.WriteLine(gwtl.ToString());
		
	}
}

class Game
{
	public string Name{set; get;}
	public int MaxNumPlayers{set; get;}
	
	public override string ToString()
	{
		return $"Maximum number of players for {Name} is {MaxNumPlayers}";
	}
	
}

class GameWithTimeLimit : Game
{
	public int TimeLimit{set; get;}
	
	public override string ToString()
	{
		return base.ToString() + $"\nTime Limit for {Name} is {TimeLimit} minutes";
		
	}
}
