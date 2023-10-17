int starter;
int ender;
bool Isnumber = false;
int evenSum = 0;
int oddSum = 0;
double evenAvarage = 0;
double oddAvarage = 0;
int evenAmount = 0;
int oddAmount = 0;

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
    Console.Write("Please enter an end value: ");
    string input = Console.ReadLine();

    Isnumber = int.TryParse(input, out ender);
}
while (!Isnumber);

for (int i = starter; i <= ender; i++)
{
    if (i % 2 == 0)
    {
        evenSum += i;
        evenAmount++;
    }
    else
    {
        oddSum += i;
        oddAmount++;
    }
}
evenAvarage = (double)(evenSum / evenAmount);
oddAvarage = (double)(oddSum / oddAmount);

Console.WriteLine($"A páros számok átlaga{evenAvarage}\nA páratlan számok átlaga{oddAvarage}");