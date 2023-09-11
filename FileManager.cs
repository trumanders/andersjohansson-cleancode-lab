
public class FileManager
{
    private string filePath = "";
    public FileManager(string filePath)
    {
        this.filePath = filePath;
    }
    public void SaveScoreToFile(Player player)
    {
        File.WriteAllText(filePath, player.Name + "#&#" + player.NumberOfGuesses);
    }

    public string[] GetFileContent()
    {
        return File.ReadAllLines(filePath);
    }
}
