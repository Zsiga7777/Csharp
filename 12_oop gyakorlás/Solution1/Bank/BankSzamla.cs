public abstract class BankSzamla
{
    public int Id { get; set; }

    public Tulajdonos Tulajdonos { get; set; }

    public int SzamlaSzam { get; set; }

    public double Egyenleg { get; set; }

    public abstract void Fizetes();

    public double EgyenlegLekerese()
    {
        return Egyenleg;
    }

    public BankSzamla()
    {
        
    }

    protected BankSzamla(int id, Tulajdonos tulajdonos, int szamlaSzam, double egyenleg)
    {
        Id = id;
        Tulajdonos = tulajdonos;
        SzamlaSzam = szamlaSzam;
        Egyenleg = egyenleg;
    }

    public override string ToString()
    {
        return $"{Id},\n {Tulajdonos},\n {SzamlaSzam},\n {Egyenleg}";
    }
}

