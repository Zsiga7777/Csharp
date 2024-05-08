
    public abstract class SuperHero : ISuperHero
    {
    public string Name { get; protected set; }
    public int Power { get; private set; } = new Random().Next(0, 100);
    public bool Fights(ISuperHero enemy)
    {
        return this.Power > enemy.Power;
    }

    }

