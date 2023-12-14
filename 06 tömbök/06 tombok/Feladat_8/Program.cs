const int NUMBEROFPLAYERS = 9;

Player[] players = GetPlayers();

double averagePoints = players.Average(x => x.NumberOfScoredPoints);
Player[] playersBelowAverage = players.Where(x => x.NumberOfScoredPoints < averagePoints).ToArray();
Console.WriteLine("\n\nJátékosok az átlag alatt: ");
ConsoleWritePlayers(playersBelowAverage);

int numberOfPlayersAboveAverage = players.Count(x => x.NumberOfScoredPoints > averagePoints);
Console.WriteLine($"\n\nJátékosok száma átlag felett: {numberOfPlayersAboveAverage}");

Player bestPlayer = GetBestPlayer(players);
Console.WriteLine($"\n\nA legtöbb gólt szerezte:{bestPlayer}");

Player[] GetPlayers()
{
    Player[] players = new Player[NUMBEROFPLAYERS];

    for (int i = 0; i < NUMBEROFPLAYERS; i++)
    {
        string name = ExtendentConsole.ReadString($"Kérem a játékos nevét: ");
        int goals = ExtendentConsole.ReadInteger(0, int.MaxValue, "Kérem a belőtt gólok számát: ");

        players[i] = new Player(name, goals);
        
    }

    return players;
}

void ConsoleWritePlayers(Player[] players)
{
   
    foreach (var player in players)
    {
        Console.WriteLine(player);
    }
}

Player GetBestPlayer(Player[] players)
{
    int maximumGoals = players.Max(x => x.NumberOfScoredPoints);
    Player bestPlayer = players.First(x => x.NumberOfScoredPoints == maximumGoals);

    return bestPlayer;
}