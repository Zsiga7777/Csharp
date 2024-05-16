
using System.Text;

public static class Hazmester
    {
    public static void Karbantart(string fajlNev)
    {
        string path = Path.Combine(Path.GetFullPath("data"), fajlNev);
        string line = null;
        string[] temp = null;
        try
        {
            using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 128);
            using StreamReader sr = new StreamReader(fs, Encoding.UTF8);

            Tarsashaz tarsashaz = new Tarsashaz(5,6);
            while (!sr.EndOfStream)
            {
                IIngatlan ingatlan;
                line = sr.ReadLine(); ;
                temp = line.Split(" ");
                if (temp[0] == "Alberlet")
                {
                    ingatlan = new Alberlet(double.Parse(temp[1]), int.Parse(temp[2]), int.Parse(temp[3]));
                    tarsashaz.LakasHozzaad(ingatlan as Lakas);
                }
                else if (temp[0] == "CsaladiApartman")
                {
                    ingatlan = new CsaladiApartman(double.Parse(temp[1]), int.Parse(temp[2]), int.Parse(temp[3]));
                    tarsashaz.LakasHozzaad(ingatlan as Lakas);
                }
                else
                {
                    ingatlan = new Garazs(double.Parse(temp[1]), int.Parse(temp[2]), temp[3] == "futott" );
                    tarsashaz.GarazsHozzaad(ingatlan as Garazs);
                }

            }

            Console.WriteLine(tarsashaz.IngatlanErtek());
        }
        catch (Exception ex)
        {
            return;
        }
    }
}

