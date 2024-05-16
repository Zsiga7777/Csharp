
using System.Text;

public static class StarWars
    {
    private static List<IEroErzekeny> EroErzekenyek = new List<IEroErzekeny>();
    public static void Szereplok(string fajlnev)
    {
        string path = Path.Combine(Path.GetFullPath("data"), fajlnev);
        string line = null;
        string[] temp = null;
        try
        {
            using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 128);
            using StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                IEroErzekeny eroErzekeny;
                line = sr.ReadLine(); ;
                temp = line.Split(" ");
                if (temp[0] == "Anakin")
                {
                    eroErzekeny = new AnakinSkywalker();
                }
                else
                {
                    eroErzekeny = new Uralkodo();
                }
                for (int i = 0; i < int.Parse(temp[1]); i++)
                {
                    (eroErzekeny as ISith).EngeddElAHaragod();
                }
                EroErzekenyek.Add(eroErzekeny);

            }
        }
        catch (Exception ex)
        {
            return ;
        }
    }

    public static void Sithek()
    {
        try
        {
            foreach (var eroErzekeny in EroErzekenyek)
            {
                Console.WriteLine(eroErzekeny);
            }
        }
        catch (Exception ex)
        {
            return;
        }
    }
}

