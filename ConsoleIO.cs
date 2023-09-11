public class ConsoleIO : IIO
{
    public string GetString()
    {
        return Console.ReadLine();
    }

    public void PrintString(string input)
    {
        Console.WriteLine(input);
    }
}