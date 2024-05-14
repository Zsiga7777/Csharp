using System.Text;

namespace Bakery
{
    public static class Pekseg
    {
        private static List<IArlap> tarolo = new List<IArlap>();

        public static async Task VasarlokAsync(string eleres)
        {
            //string path = Path.Combine(Path.GetFullPath("data"), eleres);
            //string line = null;
            //string[] temp = null;
            //try
            //{
            //    using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 128);
            //    using StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            //    List<IArlap> tempTarolo = new List<IArlap>();
            //    while (!sr.EndOfStream)
            //    {
            //        IArlap arlap;
            //        line =await sr.ReadLineAsync(); ;
            //        temp = line.Split(" ");
            //        if (temp[0] == "Pogacsa")
            //        {
            //            arlap = new Pogacsa(double.Parse(temp[2]), double.Parse(temp[1]));
            //        }
            //        else
            //        {
            //            arlap = new Kave(temp[1] == "habos" ? true : false);
            //        }
            //        tempTarolo.Add(arlap);

            //    }
            //    Tarolo = tempTarolo;
            //}
            //catch (Exception ex)
            //{
            //    return;
            //}

            foreach (var line in await File.ReadAllLinesAsync($"data/{eleres}", Encoding.UTF8))
            {
                string[] data = line.Split(" ");
                IArlap aru = PeksutemenyFactory.AruEloalitasa(data);

                tarolo.Add(aru);
            }

        }
        public static async Task EtelLeltarAsync()
        {
            //string path = Path.Combine(Path.GetFullPath("data"), "leltar.txt");

            //using FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, 128);
            //using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            //foreach (IArlap arlap in tarolo)
            //{
            //    if (arlap.GetType().Name == "Pogacsa")
            //    {
            //        sw.WriteLine(arlap);
            //    }
            //}
            try
            {
                IEnumerable<string?> pogacsak = tarolo.Where(x => x.GetType() == typeof(Pogacsa))
                    .Select(x => x.ToString());

                await File.WriteAllLinesAsync("leltar.txt", pogacsak);
            }
            catch(Exception ex)
            {
                throw new Exception("leltar.txt letrehozasa hibara futott.");
            }
            }
    }
}
