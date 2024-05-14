namespace Bakery
{
    public abstract class Peksutemeny : IArlap
    {
        private double alapar = 0;

        protected double Mennyiseg { get; set; }

        public abstract void Megkostol();

        public double MennyibeKerul() => alapar * Mennyiseg;

        protected Peksutemeny(double alapAr, double mennyiseg)
        {
            alapar = alapAr;
            Mennyiseg = mennyiseg;
        }

        public override string ToString()
        {
            return $"{Mennyiseg} db - {MennyibeKerul()} Ft";
        }
    }
}
