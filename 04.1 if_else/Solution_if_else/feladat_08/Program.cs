Console.Write("Please enter a number: ");
int number = int.Parse(Console.ReadLine());     

if(number % 4 == 0 && number % 6 == 0)
{
    Console.WriteLine("A szam oszthato 4-el es 6-al.");
}
else
{
    Console.WriteLine("A szam nem oszthato 4-es es 6-al");
}

Console.ReadKey();