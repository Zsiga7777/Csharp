
    internal class Genre
    {
    public string Name { get; set; }
    public int NumberOfGames { get; set; }

    public Genre() { }

    public Genre(string name, int numberOfGames)
    {
        Name = name;
        NumberOfGames = numberOfGames;
    }
    }
