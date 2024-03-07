
    public class PlayerWithNameAndHeight
    {
    public string Name { get; set; }
    public double Height { get; set; }

    public PlayerWithNameAndHeight() { }

    public PlayerWithNameAndHeight(string name, double height)
    {
        Name = name;
        Height = height;
    }
    public override string ToString()
    {
        return $"{Name}, {Height:F1} cm";
    }
}

