
   public class TeamWinAndLoseRatio
    {
    public string TeamName { get; set; }
    public List<int> ScoredPoints { get; set; }

    public int NumberOfLoses => ScoredPoints.Count(x => x == 1);
    public int NumberOfWins => ScoredPoints.Count(x => x == 3);

    public double WinLoseRatio => NumberOfWins / (double)NumberOfLoses;

    public TeamWinAndLoseRatio() { }

    public TeamWinAndLoseRatio(string teamName, List<int> scoredPoints ) {
    TeamName = teamName;
        ScoredPoints = scoredPoints;
    
    }

    public override string ToString()
    {
        return $"{TeamName}, {NumberOfWins} : {NumberOfLoses} azaz a győzelem-veszteség arány: {WinLoseRatio:F3}";
    }
}
