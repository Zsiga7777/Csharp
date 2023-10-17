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


for (int i = ender; i >= starter; i--)
    { Console.WriteLine(i); }
