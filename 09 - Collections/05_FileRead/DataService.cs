
    public class DataService
    {
    public static async Task<List<int>> MakeStringListToIntListAsync(string teamsPoints)
    { 
        List<int> result = new List<int>();
        string[] temp = teamsPoints.Split(',');
        int tempNumber = 0;
        foreach (var point in temp)
        {

             int.TryParse(point ,out tempNumber );
            result.Add(tempNumber);
        }
        return result;
    }

    public static async Task<List<TeamWithPlacement>> GetTeamsWithPlacementAsync(int numberOfPlaces, List<Team> teams)
    { 
        List<TeamWithPlacement> result = new List<TeamWithPlacement>();
        TeamWithPlacement teamsWithPlacement = null;
        teams = teams.OrderByDescending(x => x.SumOfPoint).ToList(); 
        for (int i = 0; i < numberOfPlaces; i++)
        {
            teamsWithPlacement = new TeamWithPlacement();
            teamsWithPlacement.SumOfPoint = teams[i].SumOfPoint;
            teamsWithPlacement.Placement = i + 1;
            teamsWithPlacement.TeamName = teams[i].TeamName;

            result.Add(teamsWithPlacement);
        }

        return result;
    }
    public static async Task<List<string>> GetLastTeamNamesAsync(int numberOfPlaces, List<Team> teams)
    {
        List<string> result = new List<string>();
        teams = teams.OrderBy(x => x.SumOfPoint).ToList();
        for (int i = 0; i < numberOfPlaces; i++)
        {
            result.Add(teams[i].TeamName);
        }

        return result;
    }
}

