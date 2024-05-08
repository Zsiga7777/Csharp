
    public abstract class Plane : IPlane
    {
    public string Model { get; protected set; }
    public string Type { get; protected set; }
    public double Speed { get; protected set; }

    protected Random random = new Random();

    protected Plane(string model, string type )
    {
        Model = model;
        Type = type;
        Speed = random.Next(100, 1000);
    }
    public abstract void Attack();
    }

