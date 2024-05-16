
using System.Text.RegularExpressions;

public class Alberlet : Lakas, IBerelheto
{
    public int FoglaltHonapokSzama {  get; set; }

    public Alberlet(double terulet, int szobakSzama,  int ar, int lakoSzemelyekSzama = 0, int foglaltHonapokSzama = 0):base(terulet,szobakSzama,lakoSzemelyekSzama,ar) 
    {
        FoglaltHonapokSzama = foglaltHonapokSzama;
    }
    public override bool Bekoltozik(int bekoltozokSzama)
    {
        if (bekoltozokSzama <= SzobakSzama * 8 && bekoltozokSzama * 2 <= Terulet)
        {
            LakoSzemelyekSzama = bekoltozokSzama;
            return true;
        }
        else
        { 
            return false;
        }
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
        };
    }

    public bool LefoglaltE()
    {
        if (FoglaltHonapokSzama > 0)
        {
            return true;
           
        }
        else
        {
            return false;
        }

    }

    public double MennyibeKerul(int honapSzama)
    {
        if (LakoSzemelyekSzama == 0)
        {
            return -1;
        }
        else
            return (OsszesKoltseg() / (double)LakoSzemelyekSzama) * (double)honapSzama;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, foglalt hónapok száma: {FoglaltHonapokSzama}";
    }
}

