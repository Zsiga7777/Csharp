List<Spaceship> spaceships = new List<Spaceship>
{
    new Enterprise("Enterprise", new Captain("Kirk", Rank.Captain)),
    new Rocinante("Rocinante", new Captain("Géza", Rank.Admiral)),
    new MilleniumFalcon("Millenium Falcon", new Captain("Han solo", Rank.Major))
};

for (int i = 0; i < spaceships.Count-1; i++)
{
    for (int j = i+1;  j < spaceships.Count; j++)
    {
        if (spaceships[i].Attack(spaceships[j]))
        {
            Console.WriteLine($"{spaceships[i].Name} hajó győzött");
        }
        else
        {
            Console.WriteLine($"{spaceships[j].Name} hajó győzött");
        }
    }
}