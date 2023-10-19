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
    Console.Write("Please enter an end value that is bigger than the previous number: ");
    string input = Console.ReadLine();

    Isnumber = int.TryParse(input, out ender);
}
while (!Isnumber || ender < starter);

if (ender % 2 != 0)
{
    ender--;
}
    for (int i = ender; i >= starter; i -= 2)
    { Console.WriteLine(i); }
