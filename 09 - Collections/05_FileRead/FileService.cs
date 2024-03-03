
public static class FileService
    {
    public static async Task<List<Team>> GetTeamsAsync(string fileName)
    {
        List<Team> teams = new List<Team>();
        Team team = null;
        string line = null;
        string linePoints = null;
        string[] data = null;

        string path = Path.Combine("source", fileName);
        using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 128);
        using StreamReader sr = new StreamReader(fs, Encoding.UTF7);

        while (!sr.EndOfStream)
        {
            line = await sr.ReadLineAsync();
            linePoints = await sr.ReadLineAsync();
           
            team = new Team();
            team.TeamName = line;
            team.ScoredPoints = await DataService.MakeStringListToIntListAsync(linePoints);

            teams.Add(team);
        }

        return teams;
    }
    }

