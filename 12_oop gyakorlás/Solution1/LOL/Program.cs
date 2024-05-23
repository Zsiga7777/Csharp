List<Champion> champions = new List<Champion>
{
    new Tank("Leona", "Sajt"),
    new Tank("Braun", "Kecske"),
    new Mage("Lux","Alma"),
    new Mage("Morgana","Körte"),
    new Archer("Kai-Sa", "Eper"),
    new Archer("Jinx", "Monitor"),
};

Random rnd = new Random();
int temp = 0;
for (int i = 0; i < champions.Count - 1; i++)
{
    for (int j = i +1; j < champions.Count; j++)
    {
        temp = rnd.Next(0, 10);
        if (temp == 3)
        {
            if (champions[j] is Tank tank)
            {
                tank.GoneMad();
            }
            else if (champions[j] is Mage mage)
            {
                mage.HokusPokus();
            }
            else
            {
                (champions[j] as Archer).Hides();
            }
        }
        else if (temp == 7)
        {
            champions[j].GetChill();
        }

        if (champions[i].Attack(champions[j]))
        {
            Console.WriteLine($"\n{champions[i].Name} nyert  {champions[j].Name} ellen");
        }
        else
        {
            Console.WriteLine($"\n{champions[i].Name} vesztett {champions[j].Name} ellen");
        }
    }
}