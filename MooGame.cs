

using System.Reflection.Emit;

public class MooGame : IPlayable
{
    private GameDependencies gameDependencies;
    private const int GoalLength = 4;
    private int cows = 0;
    private int bulls = 0;

    private IIO io;
    private Player player;
    private Statistics statistics;
    private Goal goal;
    private FileManager fileManager;

    public MooGame() { }

    public MooGame(GameDependencies gameDependencies)
    {
        this.io = gameDependencies.Io;
        this.player = gameDependencies.Player;
        this.statistics = gameDependencies.Statistics;
        this.goal = gameDependencies.Goal;
        fileManager = new FileManager("results.txt");
    }

    public void Play()
    {
        do
        {
            InitializeGame();
            io.PrintString("New game:\n");
            do
            {
                player.Guess = io.GetString();
                string clueString = GetClueString();

               io.PrintString(clueString + "\n");
            } while (bulls < 4);
            fileManager.SaveScoreToFile(player);
            statistics.ShowHiScore(fileManager.GetFileContent());
            io.PrintString("Correct, it took " + player.NumberOfGuesses + " guesses\nContinue?");
        } while (io.GetString().ToLower().Substring(0, 1) == "y");
    }  

    private string GetClueString()
    {
        bulls = 0;
        cows = 0;
        int playerGuessLength = player.Guess.Length;
        if (playerGuessLength > goal.GoalLength) playerGuessLength = goal.GoalLength;
        for (int i = 0; i < GoalLength; i++)
        {
            for (int j = 0; j < playerGuessLength; j++)
            {
                if (goal.GoalString[i] == player.Guess[j])
                {
                    if (i == j) bulls++;                    
                    else cows++;                    
                }
            }
        }
        return "BBBB".Substring(0, bulls) + "CCCC".Substring(0, cows);
    }   

    public void InitializeGame()
    {        
        goal = new GoalBuilder().SetGoalLength(GoalLength).GenerateRandomGoal().Build();
        player.ResetGame();
    }
}