
    public class TeamWithPlacement
    {
    public string TeamName { get; set; }

    public int  SumOfPoint { get; set; }

    public int Placement { get; set; }

    public TeamWithPlacement() { }
    public TeamWithPlacement(string teamName, int sumOfPoint, int placement)
    {
        TeamName = teamName;
        SumOfPoint = sumOfPoint;
        Placement = placement;
    }

    public override string ToString()
    {
        return $"{Placement} - {TeamName} {SumOfPoint}";
    }
}

