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

for (int i = -1; i <= stepNumber * 2; i += 2)
{
    for (int j = i / 2; j < stepNumber - 1; j++)
    {
        Console.Write("  ");
    }
    for (int k = 1; k <= i; k++)
    {

        Console.Write($"{k} ");
    }
    Console.WriteLine();
}

for (int i = 1; i <= stepNumber; i ++)
{
    Console.Write("  ");
    for (int j = 1 ; j <= stepNumber*2-3; j++)
    {
        Console.Write($"{j} ");
    }
    Console.WriteLine();
}