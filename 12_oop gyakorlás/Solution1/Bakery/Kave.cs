

namespace Bakery
{
    public class Kave : IArlap
    {
        private bool habosE = false;

        private const int CSESZEKAVE = 180;

        public Kave(bool habosE)
        {
            this.habosE = habosE;
        }

       public double MennyibeKerul()
        {
            if (habosE)
            {
                return CSESZEKAVE * 1.5;
            }
            else
            {
                return (double)CSESZEKAVE;
            }
        }

        public override string ToString()
        {
            return $"{(habosE? "Habos" : "Nem habos")} kávé {MennyibeKerul()}";
        }
    }
}
