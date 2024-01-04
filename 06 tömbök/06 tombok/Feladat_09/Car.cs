
public class Car
{
    public int Speed { get; set; }
    public string Plate { get; set; }

    public int Penalty { get; set; }



    public Car()
    { }

    public Car(int speed, string plate, int penalty)
    {
        Speed = speed;
        Plate = plate;
        Penalty = penalty;
    }

    public override string ToString()
    {
        return $"{this.Plate} rendszámú autó haladt {this.Speed} km/h-val, büntetése:{this.Penalty} Ft";
    }
}