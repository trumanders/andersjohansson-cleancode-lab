using andersjohansson_laboration;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MooGame;

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


    public MooGame(GameDependencies gameDependencies)
    {
        this.io = gameDependencies.Io;
        this.statistics = gameDependencies.Statistics;
        this.player = gameDependencies.Player;
        this.goal = gameDependencies.Goal;
        this.goalBuilder = gameDependencies.GoalBuilder;
    }

    public void Play()
    {
        do
        {
            InitializeGame();
            io.PrintString("New game:\n");
            //comment out or remove next line to play real games!
            // io.PrintString("For practice, number is: " + Goal + "\n");

            do
            {
                player.Guess = io.GetString();
                io.PrintString(GetClueString() + "\n");
            } while (bulls < 4);

            using (StreamWriter output = new StreamWriter("result.txt", append: true))
            {
                output.WriteLine(player.Name + "#&#" + player.NumberOfGuesses);
            }
 
            ShowTopList();
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

    private void ShowTopList()
    {
        io.PrintString($"{"Player", -20}{"Games", 5}{"Average", 10}");
        var showSortedScoreList = File.ReadLines("result.txt")
            .Select(nameAndScore => nameAndScore.Split("#&#"))
            .GroupBy(nameAndScore => nameAndScore[0])
            .ToDictionary(
                group => group.Key,
                group => (
                    times: group.Count(),
                    average: group.Select(part => int.Parse(part[1])).Average()
                ))
            .OrderBy(average => average.Value.average);
        foreach (var player in showSortedScoreList)
            io.PrintString($"{player.Key, -20}{player.Value.times, 5}{player.Value.average, 10:F2}");
    }

    private void InitializeGame()
    {        
        
        goal = new GoalBuilder().SetGoalLength(GoalLength).GenerateRandomGoal().Build();
        player.ResetGame();
    }
}