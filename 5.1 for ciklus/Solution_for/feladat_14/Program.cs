int starter;
int ender;
bool Isnumber = false;
int canBeDividedW5 = 0;
int canBeDividedW7 = 0;


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
    if (i % 5 == 0)
    {
        canBeDividedW5 += i;
    }
    if ( i % 7 == 0)
    { 
        canBeDividedW7 += i;
    }
}

if (canBeDividedW5 > canBeDividedW7)
{
    Console.WriteLine($"Az 5-tel osztható számok összege a nagyobb, {canBeDividedW5}");
}
else if (canBeDividedW5 < canBeDividedW7)
{
    Console.WriteLine($"A 7-tel osztható számok összege a nagyobb, {canBeDividedW7}");
}
else
{
    Console.WriteLine($"Az 5-tel és 7-tel osztható számok összege egyenlő, {canBeDividedW5} ");
}


