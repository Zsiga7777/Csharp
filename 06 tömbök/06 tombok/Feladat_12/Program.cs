using Custom.Library.ConsoleExtensions;

const int NUMBEROFPLAYERS = 3;

Player[] players = GetPlayers();

Console.Clear();

int pointScored = players.Sum(player => player.ScoredPoints);
Console.WriteLine($"A játékosok által összesen szerzett pontok száma: {pointScored}");



Player[] GetPlayers()
{
    Player[] players = new Player[NUMBEROFPLAYERS];
    string name = "";
    int point = 0;
    for (int i = 0; i < NUMBEROFPLAYERS; i++)
    {
        name = ExtendentConsole.ReadString("Kérem a játékos nevét: ");
        point = ExtendentConsole.ReadInteger(0, "Kérem a játékos nevét: ");
        players[i] = new Player(name, point);
    }

    return players;
}