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

for (int i = stepNumber; i >= 1; i--)
{
    for (int j = i; j >= 1; j--)
    {
        Console.Write($"{j} \t");
    }
    Console.WriteLine();
}