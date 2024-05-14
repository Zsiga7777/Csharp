
namespace Vehicle
{
    public class AudiS8 : Jarmu
    {
        public bool LezerBlokkolo {  get; set; }

        public AudiS8(string rendszam, int aktSebesseg, bool lezerBlokkolo) : base(aktSebesseg, rendszam)
        {
            LezerBlokkolo = lezerBlokkolo;
        }

        public override bool GyorshajtottE(int maxEngSebesseg)
        {
            if(LezerBlokkolo) return false;

            if (AktSebesseg > maxEngSebesseg)
            {
                return true;
            }
            else { return false; }
        }
        public override string ToString()
        {
            return $"Audi: {base.ToString()}";
        }
    }
}
