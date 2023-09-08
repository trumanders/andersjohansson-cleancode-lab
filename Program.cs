using andersjohansson_laboration;

namespace MooGame;

public class Program
{
	public static void Main(string[] args)
	{
        IIO io = new ConsoleIO();
        Player player = new Player();
        Statistics statistics = new Statistics(io);
        Goal goal = new Goal();
        GoalBuilder goalBuilder = new GoalBuilder();

        io.PrintString("Enter your user name:\n");
        player.Name = io.GetString();

        var gameDependencies = new GameDependencies()
        {
            Io = io,
            Player = player,
            Statistics = statistics,
            Goal = goal,
            GoalBuilder = goalBuilder,
        };
        IPlayable game = new MooGame(gameDependencies);
        game.Play();	
	}
}