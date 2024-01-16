using Custom.Library.ConsoleExtensions;

const int NUMBEROFPLAYERS = 6;

Player[] players = GetPlayers();

Console.Clear();

double average = players.Average(p => p.ScoredPoints);
int numberOfPlayersBelowAverage = players.Count(p => p.ScoredPoints < average);
Console.WriteLine($"Összesen {numberOfPlayersBelowAverage} db játékos teljesített átlag alatt.");


Player[] aboveAveragePlayers = players.Where(p => p.ScoredPoints > average).ToArray();
Console.WriteLine("\nEzek a játékosok teljesítettek átlag felett: ");
WritePlayers(aboveAveragePlayers);

int minPoint = players.Min(p => p.ScoredPoints);
Player[] playersWithLessPoints = players.Where(p => p.ScoredPoints == minPoint).ToArray();
Console.WriteLine("\nEzek a játékosok szerezték a legkevesebb pontot: ");
WritePlayers(playersWithLessPoints);

Player[] GetPlayers()
{
    string name = "";
    int point = 0;
    Player[] players = new Player[NUMBEROFPLAYERS];

    for (int i = 0; i < NUMBEROFPLAYERS; i++)
    {
        name = ExtendentConsole.ReadString("Kérem a játékos nevét: ");
        point = ExtendentConsole.ReadInteger(0, "Kérem a játékos által szerzett pontokat: ");
        players[i] = new Player(name, point);  
    }

    return players;
}

void WritePlayers(Player[] players)
{
    foreach (var player in players)
    {
        Console.WriteLine(player);
    }
}