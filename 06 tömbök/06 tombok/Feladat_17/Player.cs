
    internal class Player
    {
    public string Name { get; set; }
    public int ScoredPoint { get; set; }
    public double Height { get; set; }

    public Player() { }

    public Player(string name, int scoredPoint, double heigth) 
    { Name = name;
      ScoredPoint = scoredPoint;
        Height = heigth;
    }

    public override string ToString()
    {
        return $"Játékos neve: {Name}, magassága: {Height}, szerzett pontjai: {ScoredPoint}";
    }
}
