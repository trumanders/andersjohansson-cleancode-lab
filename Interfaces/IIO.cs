public interface IIO
{
    public string FilePath { get; }
    public string GetString();
    public void PrintString(string input);

    public void SetFilePath(string filePath);

    public string[] GetFileContent();
}