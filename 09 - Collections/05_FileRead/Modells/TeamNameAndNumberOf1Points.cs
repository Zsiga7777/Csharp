
    public class TeamNameAndNumberOf1Points
    {
    public string TeamName { get; set; }

    public int NumberOfOnePoints { get; set; }

    public TeamNameAndNumberOf1Points() { }

    public TeamNameAndNumberOf1Points(string teamName, int numberOfOnePoints)
    {
        TeamName = teamName;
        NumberOfOnePoints = numberOfOnePoints;
    }

    public override string ToString()
    {
        return $"{TeamName}, döntetlenek száma: {NumberOfOnePoints}";
    }
}

