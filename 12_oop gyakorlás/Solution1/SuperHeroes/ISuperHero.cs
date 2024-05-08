public interface ISuperHero
{
    string Name { get; }

    int Power { get; }

    bool Fights(ISuperHero enemy);
}
