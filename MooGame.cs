using System.Runtime.InteropServices;

namespace MooGame;

public class MooGame : IPlayable
{
    private const int GoalLength = 4;
    private readonly Player player;
    public string Goal { get; set; } = "";

    private int cows = 0;
    private int bulls = 0;   

    private readonly IIO io;

    public MooGame(Player player, IIO io)
    {
        this.player = player;
        this.io = io;
    }

    public void Play()
    {
        string answer = "";
        do
        {
            ResetGame();
            io.PrintString("New game:\n");
            //comment out or remove next line to play real games!
            io.PrintString("For practice, number is: " + Goal + "\n");

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
            Console.WriteLine("Correct, it took " + player.NumberOfGuesses + " guesses\nContinue?");
            answer = io.GetString();
            answer = answer.ToLower();
        } while (answer.Substring(0, 1) == "y");
    }

    private void SetGoal()
    {
        Goal = "";
        Random randomGenerator = new Random();
        for (int i = 0; i < 4; i++)
        {
            int random = randomGenerator.Next(10);
            string randomDigit = "" + random;
            while (Goal.Contains(randomDigit))
            {
                random = randomGenerator.Next(10);
                randomDigit = "" + random;
            }
            Goal += randomDigit;
        }
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
                if (Goal[i] == player.Guess[j])
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
        io.PrintString($"{"Name", -20}{"Score", 5}{"Average", 10}");

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
        {
            io.PrintString($"{player.Key, -20}{player.Value.times, 5}{player.Value.average, 10:F2}");
        }
    }

    private void ResetGame()
    {        
        SetGoal();
        player.ResetGame();
    }
}