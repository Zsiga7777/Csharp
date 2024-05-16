
    public class MilleniumFalcon : IUrhajo, IHiperhajtomu
    {
        public double Tapasztalat {get; set; }

    public MilleniumFalcon(double tapasztalat = 100)
    {
        Tapasztalat = tapasztalat;
    }

    public bool LegyorsuljaE(IUrhajo urhajo)
    {
        if (urhajo.MilyenGyors() < this.MilyenGyors())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public double MilyenGyors()
    {
       return Tapasztalat*2;
    }

    public void HiperUgras()
    {
        Tapasztalat+=500;
    }
    public override string ToString()
    {
        return $"Millenium Falcon: {Tapasztalat}";
    }
}
