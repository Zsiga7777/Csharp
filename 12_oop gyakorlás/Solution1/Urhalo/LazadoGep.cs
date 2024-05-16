public abstract class LazadoGep : IUrhajo
{
    protected double Sebesseg {  get; set; }

    protected bool MeghibasodhatE {  get; set; }

    public LazadoGep(double sebesseg, bool meghibasodhatE)
    {
        Sebesseg = sebesseg;
        MeghibasodhatE = meghibasodhatE;
    }

    public abstract bool ElkapjaAVonosugar();
    public bool LegyorsuljaE(IUrhajo urhajo)
    {
        if (urhajo is MilleniumFalcon falcon)
        {
            if (falcon.MilyenGyors() * 2 < this.MilyenGyors())
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
            if (urhajo.MilyenGyors() < this.MilyenGyors() && (urhajo as LazadoGep).MeghibasodhatE)
            {
                return true;
            }
            else
            {
                return false;
                }
        }
    }

    public double MilyenGyors()
    {
        return Sebesseg;
    }

    public override string ToString()
    {
        return $"{Sebesseg} {(MeghibasodhatE? "meghibásodhat" : "nem hibásodhat meg.")}";
    }
}

