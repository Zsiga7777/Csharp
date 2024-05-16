
    public class Tarsashaz
    {
    public List<IIngatlan> Ingatlans { get; set; } = new List<IIngatlan>();

    public int LakasokMaxSzama {  get; set; }

    public int GarazsokMaxSzama { get; set; }

    public Tarsashaz(int lakasokMaxSzama = 1, int garazsokMaxSzama = 1) 
    {
        LakasokMaxSzama = lakasokMaxSzama;
        GarazsokMaxSzama = garazsokMaxSzama;
    }

    public bool LakasHozzaad(Lakas lakas)
    {
        if (Ingatlans.Count(x => x.GetType() == typeof(Lakas)) < LakasokMaxSzama)
        {
            Ingatlans.Add(lakas);
            return true;
        }
        else
        { 
            return false;
        }
    }
    public bool GarazsHozzaad(Garazs garazs)
    {
        if (Ingatlans.Count(x => x.GetType() == typeof(Garazs)) < LakasokMaxSzama)
        {
            Ingatlans.Add(garazs);
            return true;
        }
        else
        {
            return false;
        }
    }

    public int OsszesLako()
    {
        return Ingatlans.Where(x => x.GetType() == typeof(Lakas)).Sum(x => (x as Lakas).LakokSzama());
    }

    public double IngatlanErtek()
    {
        double ertek = 0;
        ertek += Ingatlans.Where(x => x is Lakas && (x as Lakas).LakokSzama() > 0).Sum(x => (x as Lakas).OsszesKoltseg());
        ertek += Ingatlans.Where(x => x is Garazs && (x as Garazs).LefoglaltE()).Sum(x => (x as Garazs).OsszesKoltseg());

        return ertek;
    }
}

