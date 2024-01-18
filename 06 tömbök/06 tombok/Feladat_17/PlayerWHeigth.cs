
    internal class PlayerWHeigth
    {
    public Player ShortestPlayer { get; set; }
    public Player TallestPlayer { get; set; }

    public double Difference => TallestPlayer.Height - ShortestPlayer.Height;
    
    public PlayerWHeigth() { }
    public PlayerWHeigth(Player shortestplayer, Player tallestPlayer) 
    {
        ShortestPlayer = shortestplayer;
        TallestPlayer = tallestPlayer;
    }

    public override string ToString()
    {
        return $"A legmagassabb játékos { TallestPlayer.Name} ({ TallestPlayer.Height})." +
            $"\nA legalacsonyabb játékos { ShortestPlayer.Name} ({ ShortestPlayer.Height})." +
            $"\nA különbség { Difference} cm";
    }
}

