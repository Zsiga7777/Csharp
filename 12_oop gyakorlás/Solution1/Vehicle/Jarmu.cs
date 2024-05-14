
namespace Vehicle
{
    public abstract class Jarmu
    {
        protected int AktSebesseg {  get; set; }

        private string rendszam; 

        public Jarmu(int aktSebesseg, string rendszam)
        {
            AktSebesseg = aktSebesseg;
            rendszam = rendszam;
        }

        public abstract bool GyorshajtottE(int SebKorlat);

        public override string ToString()
        {
            return $"{rendszam} - {AktSebesseg} km/h";
        }
    }
}
