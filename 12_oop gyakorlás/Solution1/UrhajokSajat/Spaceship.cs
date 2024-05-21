
public abstract class Spaceship
{
    protected static Random Rnd = new Random();
    public string Name { get; set; }
    public Captain Captain { get; set; }

    public bool Destructed { get; set; }

    public int Speed { get; set; } = Rnd.Next(100, 1000);
    public int Shield { get; set; } = Rnd.Next(10, 200);

    public abstract bool Attack(Spaceship enemyShip);

    public void Selfdistruct()
    {
        Destructed = true;
    }

    protected Spaceship(string name, Captain captain)
    {
        Name = name;
        Captain = captain;
    }

    public override string ToString()
    {
        return $"{Name}, {Captain}, {(Destructed ? "megsemmisült" : "nem semmisült meg")}, {Speed}, {Shield}";
    }

}

