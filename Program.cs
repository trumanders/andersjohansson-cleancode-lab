public class Program
{    
    private static IPlayable game;
    private static GameDependencies gameDependencies;
    private static IIO io = new ConsoleIO();

    public static void Main(string[] args)
	{
         gameDependencies= new GameDependencies()
         {
             Io = io,
             Player = new Player(),
             Statistics = new Statistics(io),
             Goal = new Goal()
         };

        io.PrintString("Enter your user name:\n");
        gameDependencies.Player.Name = io.GetString();
       
        IPlayable game = new MooGame(gameDependencies);
        game.Play();	
	}
}