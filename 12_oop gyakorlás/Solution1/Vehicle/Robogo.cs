
namespace Vehicle
{
    public class Robogo : Jarmu, IKisGepjarmu
    {
        public int MaxSebesseg { get; set; }

        public Robogo(int aktSebesseg, string rendszam, int maxSebesseg) : base(aktSebesseg, rendszam)
        {
            MaxSebesseg = maxSebesseg;
        }

        public override bool GyorshajtottE(int maxEngSebesseg)
        {
            if (AktSebesseg > maxEngSebesseg)
            {
                return true;
            }
            else { return false; }
        }
        public bool HaladhatItt(int sebesseg)
        {
            if (sebesseg < MaxSebesseg)
            { 
                return false;
            }
            else
            {
                return true;
            }
        }
        public override string ToString()
        {
            return $"Robogo: {base.ToString()}";
        }
    }
}
