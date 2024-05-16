
public class Vasember : Bosszuallo, IMilliardos
{


    public Vasember(double szuperero = 150, bool vanEGyengesege = true) : base(szuperero, vanEGyengesege)
    {
        
    }

    public void KutyutKeszit()
    {
        Random rnd = new Random();
        Szuperero += rnd.Next(0, 10) + rnd.NextDouble(); 
    }

    public override bool MegmentiAVilagot()
    {
        if (Szuperero > 1000)
        { 
            return true; 
        }
        else 
        { 
            return false; 
        }
    }
    public override string ToString()
    {
        return $"Vasember: {base.ToString()}";
    }
}
