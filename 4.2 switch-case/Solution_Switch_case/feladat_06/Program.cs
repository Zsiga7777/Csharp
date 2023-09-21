Console.Write("Please enter the lenght of the brick: ");
int lenght = int.Parse(Console.ReadLine());

Console.Write("Please enter the width of the brick: ");
int width = int.Parse(Console.ReadLine());

Console.Write("Please enter wich property of the brick, you want\nt - terulet\nk - kerulet\na - atlo: ");
string sign = Console.ReadLine().ToLower();

double? result = sign switch
{
    "k" => 2*(lenght+width),
    "t" => lenght * width,
    "a" => (double)(Math.Sqrt(Math.Pow(lenght, 2) + Math.Pow(width, 2))),
    _ => null,
};
if (result == null)
{
    Console.WriteLine("Ilyen tulajdonság nincs");
}
else
{
    Console.WriteLine(result);
}
Console.ReadKey();