Console.Write("Please enter a number: ");
int number1 = int.Parse(Console.ReadLine());

Console.Write("Please enter another number: ");
int number2 = int.Parse(Console.ReadLine());

Console.Write("Please enter a mathematical sign: ");
string sign = Console.ReadLine();

double? result = sign switch
{
    "+" => number1 + number2,
    "-" => number1 - number2,
    "*" => number1 * number2,
    "/" => number1 / (double)number2,
    _ => null,
};
if( result == null)
{
    Console.WriteLine("Ilyen operátor nincs");
}
else
{ 
    Console.WriteLine(result);
}

Console.ReadKey();