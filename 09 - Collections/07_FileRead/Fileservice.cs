
public static class Fileservice
    {
    public static async Task<List<Player>> GetStudentsAsync(string fileName)
    {
        List<Player> players = new List<Player>();
        Player player = null;
        string line = null;
        string[] data = null;

        string path = Path.Combine("source", fileName);

        using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 128);
        using StreamReader sr = new StreamReader(fs, Encoding.UTF7);

        await sr.ReadLineAsync();

        while (!sr.EndOfStream)
        {
            player = new Player();

            line = await sr.ReadLineAsync();
            data = line.Split(";");
            player.Name = data[0];
            player.FirstMatch =DateTime.Parse( data[1]);
            player.LastMatch = DateTime.Parse(data[2]);
            player.Weight = int.Parse(data[3]);
            player.Height = int.Parse(data[4]);
            players.Add(player);
        }

        return players;
    }
}

