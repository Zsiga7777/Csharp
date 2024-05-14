
using System.Text;

namespace Vehicle
{
    public static class Orszagut
    {
        private static List<Jarmu> jarmuvek = new List<Jarmu>();

        public static void JarmuvekJonnek(string eleres)
        {
            string path = Path.Combine(Path.GetFullPath("data"), eleres);
            string line = null;
            string[] temp = null;
            try
            {
                using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 128);
                using StreamReader sr = new StreamReader(fs, Encoding.UTF8);
                while (!sr.EndOfStream)
                {
                    Jarmu jarmu;
                    line = sr.ReadLine(); ;
                    temp = line.Split(";");
                    if (temp[0] == "robogo")
                    {
                        jarmu = new Robogo(int.Parse(temp[2]), temp[1], int.Parse(temp[3]));
                    }
                    else
                    {
                        jarmu = new AudiS8(temp[1], int.Parse(temp[2]), bool.Parse(temp[3]));
                    }
                    jarmuvek.Add(jarmu);

                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
        public static void KiketMertunkBe()
        {
            string path = Path.Combine(Path.GetFullPath("data"), "buntetes.txt");

            using FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, 128);
            using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            foreach (Jarmu jarmu in jarmuvek)
            {
                if (jarmu.GetType().Name == "AudiS8")
                {
                    sw.WriteLine($"{jarmu}, {(jarmu.GyorshajtottE(90) ? "gyors hajtott" : "nem hajtott gyorsa")}");
                }
                else
                {
                    sw.WriteLine($"{jarmu}, {((jarmu as Robogo).HaladhatItt(90) ? "haladhat " : "nem haladhat")} az úton");
                }
            }

        }

    }
}
