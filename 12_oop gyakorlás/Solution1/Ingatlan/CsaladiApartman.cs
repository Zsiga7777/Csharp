
public class CsaladiApartman : Lakas
{
    public int GyerekekSzama {  get; set; }

    public CsaladiApartman(double terulet, int szobakSzama,  int ar,int lakoSzemelyekSzama =0 , int gyerekekSzama = 0) : base(terulet, szobakSzama, lakoSzemelyekSzama, ar)
    { 
        GyerekekSzama = gyerekekSzama;
    }
    public override bool Bekoltozik(int bekoltozokSzama)
    {
        if (GyerekSzuletik() && bekoltozokSzama-GyerekekSzama <= SzobakSzama * 2 && (bekoltozokSzama-GyerekekSzama) * 10 + GyerekekSzama * 5<= Terulet)
        {
            LakoSzemelyekSzama = bekoltozokSzama;
            return true;
        }
        else
        {
            return false;
        };
    }

    public bool GyerekSzuletik()
    {
        if (LakoSzemelyekSzama - GyerekekSzama >= 2)
        {
            LakoSzemelyekSzama++;
            GyerekekSzama++;
            return true;
        }
        else
        { 
            return false;
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()}, gyerekekSzáma: {GyerekekSzama}";
    }
}

