
    internal class Car
    {
    public string Plate { get; set; }
    public double AmountOfFuel  { get; set; }

    public Car() { }

    public Car(string plate, double amountOfFuel)
    {
        Plate = plate;
        AmountOfFuel = amountOfFuel;
    }

    public override string ToString()
    {
        return $"Az autó rendszáma: {this.Plate}, az autós által tankolt mennyiség: {this.AmountOfFuel}";
    }
}
