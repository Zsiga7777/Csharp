
public abstract class Bosszuallo : ISzuperhos
{
    protected double Szuperero {  get; set; }

    protected bool VanEGyengesege { get; set; }

    public Bosszuallo(double szuperero, bool vanEGyengesege)
    {
        Szuperero = szuperero;
        VanEGyengesege = vanEGyengesege;
    }

    public abstract bool MegmentiAVilagot();

    public bool LegyoziE(ISzuperhos szuperhos)
    {
        //bool nyerE = false;
        // if (szuperhos.GetType() == typeof(Bosszuallo))
        // {
        //     if (this.Szuperero > szuperhos.MekkoraAzEreje() && !this.VanEGyengesege)
        //     {
        //         nyerE = true;
        //     }
        //     else
        //     {
        //         nyerE = false;
        //     }
        // }
        // else
        // {
        //     if (this.Szuperero > szuperhos.MekkoraAzEreje() * 2)
        //     {
        //         nyerE = true;
        //     }
        //     else
        //     {
        //         nyerE = false;
        //     }
        // }
        // return nyerE;

        bool nyerE = false;
        if (szuperhos is Bosszuallo b)
        {
            if (this.Szuperero > szuperhos.MekkoraAzEreje() && b.VanEGyengesege)
            {
                nyerE = true;
            }
            else
            {
                nyerE = false;
            }
        }
        else
        {
            if (this.Szuperero > szuperhos.MekkoraAzEreje() * 2)
            {
                nyerE = true;
            }
            else
            {
                nyerE = false;
            }
        }
        return nyerE;
    }

    public double MekkoraAzEreje()
    {
       return Szuperero;
    }

    public override string ToString()
    {
        return $"{Szuperero}; {(VanEGyengesege? "van" : "nincs")} gyengesége ";
    }
}

