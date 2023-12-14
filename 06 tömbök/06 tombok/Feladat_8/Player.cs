    internal class Player
    {
    public string Name { get; set; }
    public int NumberOfScoredPoints { get; set; }

    public Player()
    {
    }

    public Player(string name, int numberOfScoredPoints)
    {
        Name = name;
        NumberOfScoredPoints = numberOfScoredPoints;
    }

    public override string ToString()
    {
        return $"{this.Name}, {this.NumberOfScoredPoints}";
    }
}

