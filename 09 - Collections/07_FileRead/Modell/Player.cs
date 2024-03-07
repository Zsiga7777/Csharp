public class Player
    {
    public string Name { get; set; }
    public DateTime FirstMatch { get; set; }
    public DateTime LastMatch { get; set; }

    public int Weight { get; set; }

    public int Height { get; set; }

    public Player() { }

    public Player(string name, DateTime firstMatch, DateTime lastMatch, int weight, int height)
    {
        Name = name;
        FirstMatch = firstMatch;
        LastMatch = lastMatch;
        Weight = weight;
        Height = height;
    }
}


