using System.Diagnostics;

namespace MooGame
{
	public class Program
	{
        static IIO io;
        static IPlayable game;

		public static void Main(string[] args)
		{
            bool playOn = true;
            io = new ConsoleIO();       // choose implementation
			
			io.PrintString("Enter your user name:\n");
            game = new MooGame(new Player(io.GetString()), io);
           
			while (playOn)
			{
                 game.Play();				
			}
		}
	}

	// class PlayerData
	// {
	// 	public string Name { get; private set; }
    //     public int NGames { get; private set; }
	// 	int totalGuess;
		

	// 	public PlayerData(string name, int guesses)
	// 	{
	// 		this.Name = name;
	// 		NGames = 1;
	// 		totalGuess = guesses;
	// 	}

	// 	public void Update(int guesses)
	// 	{
	// 		totalGuess += guesses;
	// 		NGames++;
	// 	}

	// 	public double Average()
	// 	{
	// 		return (double)totalGuess / NGames;
	// 	}

		
	//     public override bool Equals(Object p)
	// 	{
	// 		return Name.Equals(((PlayerData)p).Name);
	// 	}

		
	//     public override int GetHashCode()
    //     {
	// 		return Name.GetHashCode();
	// 	}
	// }
}