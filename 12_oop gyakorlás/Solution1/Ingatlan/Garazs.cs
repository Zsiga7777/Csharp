
public class Garazs : IBerelheto, IIngatlan
{
    public double Terulet { get; set; }
    public int Ar { get; set; }

    public bool FutottE {  get; set; }

    public int FoglaltHonapokSzama {  get; set; }

    public bool AllEBenneAuto {  get; set; }

    public Garazs(double terulet, int ar, bool futottE, int foglaltHonapokSzama = 0, bool allEBenneAuto = false) 
    {
        Terulet = terulet;
        Ar = ar;
        FutottE = futottE;
        FoglaltHonapokSzama = foglaltHonapokSzama;
        AllEBenneAuto = allEBenneAuto;
    }

    public bool Lefoglal(int honapokSzama)
    {
        if (LefoglaltE())
        {
            return false;
        }
        else
        {
            FoglaltHonapokSzama = honapokSzama;
            return true;

        }
    }

    public bool LefoglaltE()
    {
        if (FoglaltHonapokSzama > 0 || AllEBenneAuto)
        {
            return true;
        }
        else
        {
            return false;
        };
    }

    public double MennyibeKerul(int honapSzama)
    {
        double eredmeny;
        if (FutottE)
        {
            eredmeny = (double)OsszesKoltseg() * 1.5;
        }
        else
        { 
            eredmeny = OsszesKoltseg();
        }
        return eredmeny * (double)honapSzama;
    }

    public double OsszesKoltseg() => Terulet * (double)Ar;

    public void AutoKiBeAll()
    {
        if (AllEBenneAuto)
        {
            AllEBenneAuto = false;
        }
        else
        { 
            AllEBenneAuto = true;
        }
    }

    public override string ToString()
    {
        return $"{Terulet}, {Ar}, {(FutottE ? "Fűtött":"Nem fűtött")}, {FoglaltHonapokSzama}, {(AllEBenneAuto? "Áll bent autó" : "Nem áll bent autó")}.";
    }
}

