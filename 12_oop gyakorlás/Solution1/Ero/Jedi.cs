
    public abstract class Jedi : IEroErzekeny
    {
    protected double Ero {  get; set; }
    protected bool AtallhatE {  get; set; }

    public Jedi(double ero, bool atallhatE)
    {
        this.Ero = ero;
        this.AtallhatE = atallhatE;
    }

    public abstract bool MegteremtiAzEgyensulyt();

    public bool LegyoziE(IEroErzekeny eroErzekeny)
    {
        if (eroErzekeny is Jedi jedi)
        {
            if (jedi.AtallhatE && jedi.MekkoraAzEreje() < this.Ero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else 
        {
            if (eroErzekeny.MekkoraAzEreje()*2 < this.Ero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public double MekkoraAzEreje()
    {
        return Ero;
    }

    public override string ToString()
    {
        return $"{Ero}. {(AtallhatE ? "Átállhat" : "Nem állhat át")} a sötét oldalra.";
    }
}

