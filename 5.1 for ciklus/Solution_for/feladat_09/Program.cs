int starter;
int ender;
bool Isnumber = false;

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

if (starter % 2 == 0)
{
    for (int i = ender; i >= starter; i -= 2)
    { Console.WriteLine(i); }
}
else
{
    for (int i = ender-1; i >= starter; i -= 2)
    { Console.WriteLine(i); }
}