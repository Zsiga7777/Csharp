int stepNumber;
bool Isnumber = false;
do
{
    Console.Write("Kérek egy lépés számot: ");
    string input = Console.ReadLine();

    Isnumber = int.TryParse(input, out stepNumber);
}
while (!Isnumber || stepNumber < 1);

Console.Clear();

for (int i = 0; i <= stepNumber; i++)
{
    for (int j = 1; j <= i; j++)
    {
        Console.Write($"{j} \t");
    }
    Console.WriteLine();
}