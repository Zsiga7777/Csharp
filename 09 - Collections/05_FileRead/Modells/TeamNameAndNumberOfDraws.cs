
    public class TeamNameAndNumberOfDraws
    {
    public string TeamName { get; set; }

    public int NumberOfDraws { get; set; }

    public TeamNameAndNumberOfDraws() { }

    public TeamNameAndNumberOfDraws(string teamName, int numberOfDraws)
    {
        TeamName = teamName;
        NumberOfDraws = numberOfDraws;
    }

    public override string ToString()
    {
        return $"{TeamName}, döntetlenek száma: {NumberOfDraws}";
    }
}
