
public class ForintBankSzamla : BankSzamla, IBetet
{
    public ForintBankSzamla(int id, Tulajdonos tulajdonos, int szamlaSzam, double egyenleg) : base(id, tulajdonos, szamlaSzam, egyenleg)
    {
    }

    public override void Fizetes(int osszeg)
    {
        if(osszeg < Egyenleg)
        {
            Egyenleg -= osszeg;
        }
        Egyenleg -= Egyenleg * 0.00001;
    }

    public void Kamatozik()
    {
        Egyenleg += Egyenleg * 0.008;
    }

    public override string ToString()
    {
        return $"{base.ToString()} HUF";
    }

}

