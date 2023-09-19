Console.Write("Please enter a number: ");
int number = int.Parse(Console.ReadLine()); 

if(number % 5 == 0)
{
    Console.WriteLine("A szam oszthato 5-tel");
}
else
{
    Console.WriteLine("A szam nem oszthato 5-tel");
}

Console.ReadKey();