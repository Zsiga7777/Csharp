int starter;
int ender;
bool Isnumber = false;
int evenSum = 0;
int oddSum = 0;


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
    if (i % 2 == 0)
    {
        evenSum+=i;
    }
    else
    {
        oddSum+=i;
    }
}

if(evenSum > oddSum)
{
    Console.WriteLine($"A páros számok összege a nagyobb, {evenSum}");
}
else if (evenSum < oddSum)
{
    Console.WriteLine($"A páratlan számok összege a nagyobb, {oddSum}");
}
else
{
    Console.WriteLine($"A páros és páratlan számok összege egyenlő, {evenSum} ");
}


