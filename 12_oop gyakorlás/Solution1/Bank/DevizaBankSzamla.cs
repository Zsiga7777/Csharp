
public class DevizaBankSzamla : BankSzamla, IBetet
{
    public DevizaTipusEnum DevizaTipus { get; set; }
    public override void Fizetes(int osszeg)
    {
        if (osszeg < Egyenleg)
        {
            Egyenleg -= osszeg;
        }
        Egyenleg -= Egyenleg * 0.000015; ;
    }

    public void Kamatozik()
    {
        Egyenleg += Egyenleg * 0.0125;
    }

    public override string ToString()
    {
        return $"{base.ToString()} {DevizaTipus}";
    }
public DevizaBankSzamla(int id, Tulajdonos tulajdonos, int szamlaSzam, double egyenleg, DevizaTipusEnum devizaTipus) : base(id, tulajdonos, szamlaSzam, egyenleg)
    {
        DevizaTipus = devizaTipus;
    }

}

