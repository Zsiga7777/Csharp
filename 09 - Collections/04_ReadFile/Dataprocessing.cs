    public class Dataprocessing
    {
    public async static Task<List<int>> ConvertStringToNumberAsync(string[] data)
    {
        List<int> ints = new List<int>();
        foreach (var item in data)
        {
          ints.Add(int.Parse(item));
        }

        return ints;
    }

    public async static Task<List<int>> GetDailyWinnerNumbersAsync(int numberOfWinnerNumbers)
    {
        List<int> result = new List<int>();
        Random rnd = new Random();
        int temp = 0;
        do
        {
            temp = rnd.Next(46);
            if (!result.Contains(temp))
            {
                result.Add(temp);
            }
            Thread.Sleep(10);
        }
        while (result.Count() < numberOfWinnerNumbers);

        return result;
    }


    public async static Task GetDailyWinnersAsync(List<LottoTip> players, List<int> winnerNumbers)
    {
        foreach (var player in players)
        {
            player.CorrectTips = winnerNumbers.Intersect(player.Tipps).Count();
        }
    }
}

