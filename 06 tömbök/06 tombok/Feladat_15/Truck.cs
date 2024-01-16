    internal class Truck
    {

    public string Plate { get; set; }
    public double Weight { get; set; }

    public Truck() { }

    public Truck(string plate, double weight)
    {
        Plate = plate;
        Weight = weight;
    }

    public override string ToString()
    {
        return $"A kamion rendszáma: {Plate}, súlya: {Weight:F2} t.";
    }
}

