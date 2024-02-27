
    public static class FileService
    {
    public static async Task<List<LottoTip>> GetLottoTipsAsync(string filename)
    { 
        List<LottoTip> result = new List<LottoTip>();
        LottoTip oneTip = null;
        string line = null;
        string[] data = null;
        string[] data2 = null;
        string path = Path.Combine("source", filename);

        using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 128);
        using StreamReader sr = new StreamReader(fs, Encoding.UTF7);

        while (!sr.EndOfStream)
        { 
           line = await sr.ReadLineAsync();
            data = line.Split("\t");
            data2 = data[1].Split(",");

            oneTip = new LottoTip();

            oneTip.TippersName = data[0];

            oneTip.Tipps = await Dataprocessing.ConvertStringToNumberAsync(data2);

            result.Add(oneTip);
        }

        return result;


    }

    public static async Task WriteToFileAsync<T>(ICollection<T> colection, string filename) 
    {
        Directory.CreateDirectory("output");
        string path = Path.Combine("output", $"{filename}.txt");

        using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
        using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

        foreach (T item in colection)
        {
            await sw.WriteLineAsync($"{item}");
        }

    }
    
}
