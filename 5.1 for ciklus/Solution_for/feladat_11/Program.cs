int starter;
int ender;
bool Isnumber = false;
int sum = 0;
int product = 1;

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

for (int i = starter ; i <= ender; i ++)
{
    if(i % 2 == 0 )
    {
        sum += i;
    }
    else { 
        product *= i; 
    }
    
}

Console.WriteLine($"Az intervallum páros számainak összege: {sum}\nAz intervallum páratlan számainak szorzata:{product}");
