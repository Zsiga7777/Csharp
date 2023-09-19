Console.Write("Please enter a number: ");
int number = int.Parse(Console.ReadLine());

if(number % 2 == 0)
{
    Console.WriteLine("A szam paros");
}
else
{
    Console.WriteLine("A szam paratlan");
}
if (number >= 0)
{
    Console.WriteLine("A szam pozitiv");
}
else
{
    Console.WriteLine("A szam negativ ");
}
if (number % 5 == 0)
{
    Console.WriteLine("A szam oszthato 5-tel");
}
else
{
    Console.WriteLine("A szam nem oszthato 5-tel");
}

Console.ReadKey();