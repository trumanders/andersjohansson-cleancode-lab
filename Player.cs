
public class Player
{
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private string name = "";
    public int NumberOfGuesses
    {
        get { return numberOfGuesses; }
    }

    private int numberOfGuesses = 0;

    public string Guess
    {
        get { return guess; }
        set
        {
            guess = value;
            numberOfGuesses++;
        }
    }

    private string guess = "";

    public Player(string name)
    {
        this.name = name;
    }

    public void ResetGame()
    {
        numberOfGuesses = 0;
    }
}