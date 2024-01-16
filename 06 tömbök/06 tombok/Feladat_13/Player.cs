
    internal class Player
    {
    public string Name { get; set; }    
    public int ScoredPoints { get; set; }

    public Player() { }

    public Player(string name, int scoredPoints) 
    {
    Name = name;
        ScoredPoints = scoredPoints;
    }

    public override string ToString()
    {
        return $"Játékos neve: {Name}, játékos pontszáma: {ScoredPoints}";
    }
}

