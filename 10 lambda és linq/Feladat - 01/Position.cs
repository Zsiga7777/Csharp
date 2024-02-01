
    internal class Position
    {
    public int NumberOfPlayers { get; set; }

    public string PositionName { get; set; }

    public Position() { }
    public Position(int number, string positionName) {
    NumberOfPlayers = number;
        PositionName = positionName;
   }
    }

