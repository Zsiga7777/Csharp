Human ember1 = new Human();
Human ember2 = new Human();

Console.Write("Please enter a name: ");
ember1.Name = Console.ReadLine();

Console.Write("Please enter an age: ");
ember1.Age = int.Parse(Console.ReadLine());

Console.Write("Please enter a weight: ");
ember1.Weight = double.Parse(Console.ReadLine());

Console.Write("Please enter a fekve nyomás: ");
ember1.FekveNyomas = double.Parse(Console.ReadLine());

ember1.Strenght = ember1.FekveNyomas / ember1.Weight;

switch (ember1.Strenght)
    {
    case <0.2:
        ember1.StrenghtRank = "kezdo";
        break;
    case <0.4:
        ember1.StrenghtRank = "halado";
        break;
    case < 1:
        ember1.StrenghtRank = "profi";
        break;
    case >1:
        ember1.StrenghtRank = "isten";
        break;

}
Console.WriteLine($"{ember1.Name} ereje {ember1.StrenghtRank}");

Console.Write("Please enter another name: ");
ember2.Name = Console.ReadLine();

Console.Write("Please enter another age: ");
ember2.Age = int.Parse(Console.ReadLine());

Console.Write("Please enter another weight: ");
ember2.Weight = double.Parse(Console.ReadLine());

Console.Write("Please enter another fekve nyomás: ");
ember2.FekveNyomas = double.Parse(Console.ReadLine());

ember2.Strenght = ember2.FekveNyomas / ember2.Weight;
switch (ember2.Strenght)
{
    case < 0.2:
        ember2.StrenghtRank = "kezdo";
        break;
    case < 0.4:
        ember2.StrenghtRank = "halado";
        break;
    case < 1:
        ember2.StrenghtRank = "profi";
        break;
    case > 1:
        ember2.StrenghtRank = "isten";
        break;

}
Console.WriteLine($"{ember2.Name} ereje {ember2.StrenghtRank}");

if (ember1.Strenght > ember2.Strenght)
{
    Console.WriteLine($"{ember1.Name} az erősebb");
}
else if (ember1.Strenght < ember2.Strenght)
{
    Console.WriteLine($"{ember2.Name} az erősebb");
}
else
{
    Console.WriteLine("Egyforma erősek.");
}