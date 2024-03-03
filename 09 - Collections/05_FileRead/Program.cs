List<Team> teams = await FileService.GetTeamsAsync("adatok.txt");

//-Hány csapat vett részt a bajnokságban?
int numberOfTeams = teams.Count;
Console.WriteLine($"\nCsapatok száma: {numberOfTeams}");

//- Ki nyerte a bajnogságot?
string winnerTeamName = teams.OrderByDescending(x => x.SumOfPoint).Select(x => x.TeamName).First();
                               
Console.WriteLine($"\nA győztes csapat: {winnerTeamName}\n");

//- Döntetlen mérkőzéskor a csapat 2 pontot szerez. Mutassa be csapatonként ki hány döntetlen mérkőzést játszott le!
List<TeamNameAndNumberOfDraws> teamNameAndNumberOfDraws = teams.Select(x => new TeamNameAndNumberOfDraws 
                                                                        {
                                                                        TeamName = x.TeamName,
                                                                        NumberOfDraws = x.ScoredPoints.Count(x => x == 2)
                                                                        }).ToList();
Console.WriteLine("\nA döntetlen meccsek száma csapatonként: ");
teamNameAndNumberOfDraws.WriteCollectionToConsole();

//- Ha egy mérkőzés 5 szetben dől el, akkor a vesztes csapat 1 pontot szerez. Mely csapatok játszottak 5 szettes mérkőzést és hányat?
List<TeamNameAndNumberOf1Points> teamNameAndNumberOf1Points = teams.Select(x => new TeamNameAndNumberOf1Points
{
TeamName = x.TeamName,
NumberOfOnePoints = x.ScoredPoints.Count(x => x == 1)
}).ToList();
Console.WriteLine("\nAz 5 szettes meccsek száma csapatonként: ");
teamNameAndNumberOf1Points.WriteCollectionToConsole();

//- Ki a  bajnogság első három helyezete. Mutassa be mintának megfelelően:
//	helyezés - csapat neve pontszám
Console.WriteLine("\nA bajnokság első 3 helyezette: ");
List<TeamWithPlacement> firstThreeTeams = await DataService.GetTeamsWithPlacementAsync(3, teams);
firstThreeTeams.WriteCollectionToConsole();

//- Az elért pontok alapján, az utolsó három csapat kiesik az első osztályból. Kik ők?
Console.WriteLine("\nAz utolsó 3 csapat: ");
List<string> lastThreeTeamNames = await DataService.GetLastTeamNamesAsync(3,teams);
lastThreeTeamNames.WriteCollectionToConsole();

//- Mutassa be csapatonként a győzelmi és verességi arányt csapatonként!
List<TeamWinAndLoseRatio> teamWinAndLoseRatios = teams.Select(x => new TeamWinAndLoseRatio
                                                                        { 
                                                                            TeamName = x.TeamName,
                                                                            ScoredPoints = x.ScoredPoints
                                                                        }).ToList();
Console.WriteLine("\nA győzelmi és veszteségi arány csapatonként: ");
teamWinAndLoseRatios.WriteCollectionToConsole();

//- Mely csapatok győzelmi aránya van az átlag alatt?
double averageWinRatio = teamWinAndLoseRatios.Average(x => x.WinLoseRatio);
List<string> teamsWithLowerWinRateThanAverage = teamWinAndLoseRatios.Where(x => x.WinLoseRatio < averageWinRatio).Select(x => x.TeamName).ToList();
Console.WriteLine($"\nCsapatok, melyek győzelmi aránya kisebb az átlagnál: ");
teamsWithLowerWinRateThanAverage.WriteCollectionToConsole();
