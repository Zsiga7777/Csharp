
using System.Text;

public class Team
    {
    public string TeamName { get; set; }

    public List<int> ScoredPoints { get; set; }

    public int SumOfPoint => ScoredPoints.Sum();

    public Team() { }
    public Team(string teamName, List<int> scoredPoints) {
        TeamName = teamName;
        ScoredPoints = scoredPoints;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"{TeamName}, szerezett pontok: ");

        foreach (int point in ScoredPoints)
        {
            sb.Append($"{point}, ");
        }

        sb.Append($", ez összese: {SumOfPoint} ");
        return sb.ToString();
    }
    }

