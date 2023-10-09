public class Player : IPlayer
{    public string Name
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
    private string guess = "";
    public string Guess
    {
        get { return guess; }
        set
        {
            guess = value;
            numberOfGuesses++;
        }
    } 
    public void ResetGame()
    {
        numberOfGuesses = 0;
    }
}

public interface IShape
{
    double CalculateArea();
}

public class Circle : IShape
{
    public double Radius { get; set; }

    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Square : IShape
{
    public double SideLength { get; set; }

    public double CalculateArea()
    {
        return SideLength * SideLength;
    }
}