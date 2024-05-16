
public abstract class Lakas : IIngatlan
{
    protected double Terulet {  get; set; }
    protected int SzobakSzama {  get; set; }
    protected int LakoSzemelyekSzama { get; set; }

    protected int Ar {  get; set; }

    public Lakas(double terulet, int szobakSzama, int lakoSzemelyekSzama, int ar)
    {
        Terulet = terulet;
        SzobakSzama = szobakSzama;
        LakoSzemelyekSzama = lakoSzemelyekSzama;
        Ar = ar;
    }

    public double OsszesKoltseg()
    {
        return Terulet * (double)Ar;
    }

    public abstract bool Bekoltozik(int bekoltozokSzama);

    public int LakokSzama() => LakoSzemelyekSzama;

    public override string ToString()
    {
        return $"{Terulet}, {SzobakSzama}, {LakoSzemelyekSzama}, {Ar}";
    }
}

