
namespace Bakery
{
    public class Pogacsa : Peksutemeny
    {
        public Pogacsa(double alapar, double mennyiseg) : base(alapar, mennyiseg)
        {
            
        }

        public override void Megkostol()
        {
            if (Mennyiseg == 0)
            {
                Console.WriteLine("Elfogyott a pogácsa.");
                return;
            }
            else
            {
                Mennyiseg /= (double)2;
                Console.WriteLine($"{Mennyiseg} pogácsa maradt.");
            };
        }

        public override string ToString()
        {
            return $"Pogácsa {base.ToString()}";
        }
    }
}
