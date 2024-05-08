List<ISuperHero> superHeroes = new List<ISuperHero>
{
    new WonderWoman("Diana"),
new Batman("Bruce Wayne"),
 new BlackWidow("Natasha")
};

for (int i = 0; i < superHeroes.Count - 1; i++)
{ 
    for (int j = i+1; j < superHeroes.Count; j++)
    {
        ISuperHero attacker = superHeroes[i];
        ISuperHero attacked = superHeroes[j];

        Console.WriteLine($"{attacker.Name} attacks {attacked.Name}");
        bool defeats = attacker.Fights(attacked);

        if(defeats)
        {
            Console.WriteLine($"{attacker.Name} wins");
        }
        else
        {
            Console.WriteLine($"{attacked.Name} wins");
        }

        await Task.Delay(1000);
    }
}

