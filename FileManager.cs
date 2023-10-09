
public class FileManager
{
    private string filePath = "";
    public FileManager(string filePath)
    {
        this.filePath = filePath;
    }
    public void SaveScoreToFile(IPlayer player)
    {
        File.AppendAllText(filePath, player.Name + "#&#" + player.NumberOfGuesses + "\n");
    }

    public string[] GetFileContent()
    {
        return File.ReadAllLines(filePath);
    }
}
