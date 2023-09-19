Console.Write("Please enter a number: ");
int x = int.Parse(Console.ReadLine());

Console.Write("Please enter another number: ");
int y = int.Parse(Console.ReadLine());

if (x % y == 0 )
{
    Console.WriteLine("A masodik szam osztoja az elsonek.");
}
else
{
    Console.WriteLine("A masodik szam nem osztoja az elsonek.");
}

Console.ReadKey();