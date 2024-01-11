using Custom.Library.ConsoleExtensions;

const int NUMBEROFPLAYERS = 3;

Player[] players = GetPlayers();

Console.Clear();

int pointScored = players.Sum(player => player.ScoredPoints);
Console.WriteLine($"A játékosok által összesen szerzett pontok száma: {pointScored}");

int maxPoint = players.Max(player => player.ScoredPoints);
Player[] playersWithMostPoint = players.Where(player => player.ScoredPoints == maxPoint).ToArray();

Console.WriteLine("\nA legtöbb pontot szerzett játékosok: ");
WritePlayers(playersWithMostPoint);

int minPoint = players.Min(player => player.ScoredPoints);
Player[] playersWithLeastPoint = players.Where(player => player.ScoredPoints == minPoint).ToArray();
Console.WriteLine("\nA legkevesebb pontot szerzett játékosok: ");
WritePlayers(playersWithLeastPoint);   

double averagePoint = players.Average(player => player.ScoredPoints);
int numberOfPlayersBelowAverage = players.Count(player => player.ScoredPoints < averagePoint);
Console.WriteLine($"\nAz átlag alatt teljesített játékosok száma: {numberOfPlayersBelowAverage}");

Player[] playersAboveAverage = players.Where(player => player.ScoredPoints > averagePoint).ToArray();
Console.WriteLine("\nAz átlag felett teljesítő játékosok neve: ");
WritePlayers(playersAboveAverage);

Player[] GetPlayers()
{
    Player[] players = new Player[NUMBEROFPLAYERS];
    string name = "";
    int point = 0;
    for (int i = 0; i < NUMBEROFPLAYERS; i++)
    {
        name = ExtendentConsole.ReadString("Kérem a játékos nevét: ");
        point = ExtendentConsole.ReadInteger(0, "Kérem a játékos által szerzett pontszámot: ");
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