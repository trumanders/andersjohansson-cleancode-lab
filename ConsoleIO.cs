public class ConsoleIO : IIO
{
    private string filePath;
    public string FilePath { get { return filePath; } }    

    public ConsoleIO(string filePath)
    {
        this.filePath = filePath;
    }
    public string GetString()
    {
        return Console.ReadLine();
    }

    public void PrintString(string input)
    {
        Console.WriteLine(input);
    }

    public void SetFilePath(string filePath)
    {
        this.filePath = filePath;
    }

    public string[] GetFileContent()
    {
        return File.ReadAllLines(filePath);
    }
}