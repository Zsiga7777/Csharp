
    public class AnakinSkywalker : Jedi, ISith
    {
    public AnakinSkywalker(double ero = 150, bool atallhatE = true) : base(ero, atallhatE)
    { }

    public void EngeddElAHaragod()
    {
        Random rnd = new Random();
        Ero += rnd.Next(0, 10) + rnd.NextDouble();
    }

    public override bool MegteremtiAzEgyensulyt()
    {
        if (Ero > 1000)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string ToString()
    {
        return $"Anakin Skywalker: {base.ToString()}";
    }
}

