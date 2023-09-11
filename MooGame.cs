

public class MooGame : IPlayable
{
    private const int GoalLength = 4;
    private int cows = 0;
    private int bulls = 0;

    private IIO io;
    private Statistics statistics;
    private Player player;
    private Goal goal;
    private GoalBuilder goalBuilder;
    private FileManager fileManager;

    public MooGame(GameDependencies gameDependencies)
    {
        this.io = gameDependencies.Io;
        this.statistics = gameDependencies.Statistics;
        this.player = gameDependencies.Player;
        this.goal = gameDependencies.Goal;
        this.goalBuilder = gameDependencies.GoalBuilder;
        this.fileManager = gameDependencies.FileManager;
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
                io.PrintString(GetClueString() + "\n");
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
        if (playerGuessLength > 4) playerGuessLength = 4;
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
        return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
    }   

    private void InitializeGame()
    {             
        goal = goalBuilder.SetGoalLength(GoalLength).GenerateRandomGoal().Build();
        player.ResetGame();
    }
}