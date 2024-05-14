using Bakery;

public static class PeksutemenyFactory
{
    public static IArlap AruEloalitasa(string[] data)
    {
        string tipus = data[0];

        return tipus switch
        {
            "Pogacsa" => new Pogacsa(double.Parse(data[2]), double.Parse(data[1])),
            "Kave" => new Kave(data[1] == "habos")

        };
    }
}

