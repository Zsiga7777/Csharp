Console.Write("Please enter a number: ");
int number = int.Parse(Console.ReadLine());
number = Math.Abs(number);

if (number > 0 && number <=9)
{
    Console.WriteLine("A szam egyjegyu.");
}
else if (number >= 10 && number <= 99)
{
    Console.WriteLine("A szam ketjegyu.");
}
else
{
    Console.WriteLine("A szam haromjegyu.");
}

Console.ReadKey();