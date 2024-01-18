using Custom.Library.ConsoleExtensions;

const int NUMBEROFPLAYERS = 6;

Player[] players = GetPlayers();

Console.Clear();

double averageHeight = players.Average(p => p.Height);
Player[] playersBelowAverageHeight = players.Where(p => p.Height < averageHeight).ToArray();
Console.WriteLine("Az átlagmagasság alatti játékosok: ");
WritePlayer(playersBelowAverageHeight);

double percentageOftallerPlayers = players.Count(p => p.Height > averageHeight) / (double)(NUMBEROFPLAYERS/(double)100);
Console.WriteLine($"\nA játékosok {percentageOftallerPlayers:F2}%-a magasabb az átlagnál");

int sumScoredPoints = players.Sum(p => p.ScoredPoint);
Console.WriteLine($"\nA játékosok által összesen szerzett pontok száma: {sumScoredPoints}");

int maxPoint = players.Max(p => p.ScoredPoint);
Player[] playersWithMaxPoint = players.Where(p => p.ScoredPoint == maxPoint).ToArray();
Console.WriteLine($"\nA legtöbb pontot szerzett játékos(ok): ");
WritePlayer(playersWithMaxPoint);

int minPoint = players.Min(p => p.ScoredPoint);
Player[] playersWithMinPoint = players.Where(p => p.ScoredPoint == minPoint).ToArray();
Console.WriteLine($"\nA legkevesebb pontot szerzett játékos(ok): ");
WritePlayer(playersWithMinPoint);

PlayerWHeigth shortestTallestPlayer = GetShortestTallestPleyer(players);
Console.WriteLine($"\nA legmagasabb és a legalacsonabb játékos:\n{shortestTallestPlayer} ");



Player[] GetPlayers()
{
    Player[] players = new Player[NUMBEROFPLAYERS];
    int point = 0;
    string name = string.Empty;
    double height = 0;

    for (int i = 0; i < NUMBEROFPLAYERS; i++)
    {
        point = ExtendentConsole.ReadInteger(0, "Kérem a szerzett pontok számát:");
        name = ExtendentConsole.ReadString("Kérem a játékos nevét: ");
        height = ExtendentConsole.ReadDouble(150, "Kérem a játékos magasságát: ");
        players[i] = new Player(name, point, height);
    }

    return players;
}

void WritePlayer(Player[] players)
{
    foreach (var player in players)
    {
        Console.WriteLine(player);
    }
}

PlayerWHeigth GetShortestTallestPleyer(Player[] players)
{
    Player tallestPlayer = new Player();
    Player shortestPlayer = new Player();
    

    double minHeight = players.Min(p => p.Height);
    double maxHeight = players.Max(p => p.Height);

    foreach (var player in players)
    {
        if (player.Height == minHeight)
        {
            shortestPlayer = player;

        }
        else if (player.Height == maxHeight)
        {
            tallestPlayer = player;
        }
    }

    PlayerWHeigth result = new PlayerWHeigth(shortestPlayer, tallestPlayer);

    return result;
}