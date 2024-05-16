
using System.Text;

public static class Kepregeny
{
    private static List<ISzuperhos> szuperhosok = new List<ISzuperhos>();

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
                ISzuperhos szuperHos;
                line = sr.ReadLine(); ;
                temp = line.Split(" ");
                if (temp[0] == "Vasember")
                {
                    szuperHos = new Vasember();
                }
                else
                {
                    szuperHos = new Batman();
                }
                for (int i = 0; i < int.Parse(temp[1]); i++)
                {
                    (szuperHos as IMilliardos).KutyutKeszit();
                }

                szuperhosok.Add(szuperHos);

            }
        }
        catch (Exception ex)
        {
            return;
        }
    }

    public static void Szuperhosok()
    {
        try
        {
            foreach (var szuperhos in szuperhosok)
            {
                Console.WriteLine(szuperhos);
            }
        }
        catch(Exception ex) 
        { 
            return; 
        }
    }
}

