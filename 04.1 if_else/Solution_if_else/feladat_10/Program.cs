Console.Write("Please enter a number: ");
int number = int.Parse(Console.ReadLine()); 

if(number % 2 == 0 && number % 3 == 0)
{
    Console.WriteLine("ZIZI");
}
else if (number % 2 == 0)
{
    Console.WriteLine("BIZ");
}
else if (number % 3 == 0)
{
    Console.WriteLine("BAZ");
}
else
{
    Console.WriteLine("A szam se 2-vel se 3-al nem oszthato.");
}

Console.ReadKey();