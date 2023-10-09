public class ConsoleIO : IIO
{
    public string GetString()
    {
        string s = Console.ReadLine();
        return string.IsNullOrEmpty(s) ? " " : s;
    }

    public void PrintString(string input)
    {
        Console.WriteLine(input);
    }
}