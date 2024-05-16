
using System.Data;
using System.Text;

public static class StarWars
    {

    private static List<IUrhajo> UrhajokTarolo = new List<IUrhajo>();
    public static void Urhajok(string fajlNev)
    {
        string path = Path.Combine(Path.GetFullPath("data"), fajlNev);
        string line = null;
        string[] temp = null;
        try
        {
            using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 128);
            using StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                IUrhajo urhajo;
                line = sr.ReadLine(); ;
                temp = line.Split(" ");
                if (temp[0] == "XWing")
                {
                    urhajo = new XWing();
                }
                else
                {
                    urhajo = new MilleniumFalcon();
                }
                for (int i = 0; i < int.Parse(temp[1]); i++)
                {
                    (urhajo as IHiperhajtomu).HiperUgras();
                }

                UrhajokTarolo.Add(urhajo);

            }
        }
        catch (Exception ex)
        {
            return;
        }
    }

    public static void Hangar()
    {
        try
        {
            foreach (var urhajo in UrhajokTarolo)
            {
                Console.WriteLine(urhajo);
            }
        }
        catch (Exception ex)
        {
            return;
        }
    }
    }

