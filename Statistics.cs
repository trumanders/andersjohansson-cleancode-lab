public class Statistics
{
    private IIO io;
    public Statistics(IIO io)
    {
        this.io = io;
    } 
    public void ShowHiScore(string[] fromContent)
    {
        io.PrintString($"{"Player",-20}{"Games",5}{"Average",10}");

        var showSortedScoreList = fromContent
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
            io.PrintString($"{player.Key,-20}{player.Value.times,5}{player.Value.average,10:F2}");
    }
}
