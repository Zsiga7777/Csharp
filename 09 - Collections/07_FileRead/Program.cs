// 2-es feladat
using Custom.Library.ConsoleExtensions;

List<Player> players = await Fileservice.GetStudentsAsync("balkezesek.csv");

// 3-as feladat
int numberOfPlayers  = players.Count;
Console.WriteLine($"Összesen {numberOfPlayers} játékos van");

//4-es feladat
List<PlayerWithNameAndHeight> playersLastPlayedin1999 = players.Where(x => x.LastMatch.Month == 10 && x.LastMatch.Year == 1999)
    .Select(x => new PlayerWithNameAndHeight
    {
    Name = x.Name,
    Height = x.Height*2.54}).ToList();
Console.WriteLine("\nJátékosok utolsó meccse 1999 októbere:");
playersLastPlayedin1999.WriteCollectionToConsole();

//5-ös feladat
Console.WriteLine();
int enteredYear = ExtendentConsole.ReadInteger(1990, 1999, "Kérem egy évszámot: ");

//6-os feladat
double averageWeight = players.Where(x => x.FirstMatch.Year <= enteredYear && x.LastMatch.Year >= enteredYear)
                              .Average(x => x.Weight);
Console.WriteLine($"\nA játékosok átlag súlya {averageWeight:F2} font ");