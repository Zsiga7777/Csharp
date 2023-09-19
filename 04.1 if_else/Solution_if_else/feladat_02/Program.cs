Console.Write("Please enter a number: ");
int number = int.Parse(Console.ReadLine());

if (number >= 0)
{
    Console.WriteLine($"A(z) {number} szam pozitiv.");
}
else
{
    Console.WriteLine($"A(z) {number} negativ");
}

Console.ReadKey();
