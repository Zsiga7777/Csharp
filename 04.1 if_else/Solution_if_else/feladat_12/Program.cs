Console.Write("Please enter a number: ");
int number = int.Parse(Console.ReadLine());

if((number > 10 && number < 20) || (number < -10 && number > -20) )
{
    Console.WriteLine("A szam a megadott tartzomanyokban van.");
}
else
{
    Console.WriteLine("A szam egyik tartomanyban sincs benne.");
}

Console.ReadKey();