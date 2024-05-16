
public class Uralkodo : IEroErzekeny, ISith
{
    public double Gonoszsag { get; set; }

    public Uralkodo(double gonoszsag = 100)
    {
        this.Gonoszsag = gonoszsag;
    }

    public void EngeddElAHaragod()
    {
        Gonoszsag +=50;
    }

    public bool LegyoziE(IEroErzekeny eroErzekeny)
    {
        if (eroErzekeny.MekkoraAzEreje() < Gonoszsag)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public double MekkoraAzEreje()
    {
       return Gonoszsag*2;
    }
    public override string ToString()
    {
        return $"Uralkodó: {Gonoszsag}";
    }
}

