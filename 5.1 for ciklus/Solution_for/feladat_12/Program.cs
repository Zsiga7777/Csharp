int starter;
int ender;
bool Isnumber = false;
int canBeDividedW3 = 0;


do
{
    Console.Write("Please enter a starter value: ");
    string input = Console.ReadLine();

    Isnumber = int.TryParse(input, out starter);
}
while (!Isnumber);
Isnumber = false;
do
{
    Console.Write("Please enter an end value that is bigger than the previous number: ");
    string input = Console.ReadLine();

    Isnumber = int.TryParse(input, out ender);
}
while (!Isnumber || ender < starter);

for (int i = starter; i <= ender; i++)
{
    if (i % 3 == 0)
    {
        canBeDividedW3 ++;
    }
}

Console.WriteLine($"Az intervallum {canBeDividedW3} szám osztható 3-mal");
