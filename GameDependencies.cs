
public class GameDependencies
{
    public IIO Io { get; set; }
    public Player Player { get; set; }
    public Statistics Statistics { get; set; }
    public Goal Goal { get; set; }
    public FileManager FileManager { get; set; } = new FileManager("results.txt");
}
