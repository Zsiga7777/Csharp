
    public class Batman : ISzuperhos, IMilliardos
    {
        public double Lelemenyesseg {  get; set; }

    public Batman(double lelemenyesseg = 100)
    {
        Lelemenyesseg = lelemenyesseg;
    }

    public void KutyutKeszit()
    {
       Lelemenyesseg +=50;
    }

    public bool LegyoziE(ISzuperhos szuperhos)
    {
        if (szuperhos.MekkoraAzEreje() < Lelemenyesseg)
        {
            return true;
        }
        else if (szuperhos.MekkoraAzEreje() < this.MekkoraAzEreje())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public double MekkoraAzEreje()
    {
        return Lelemenyesseg*2;
    }
    public override string ToString()
    {
        return $"Batman: {Lelemenyesseg}";
    }
}

