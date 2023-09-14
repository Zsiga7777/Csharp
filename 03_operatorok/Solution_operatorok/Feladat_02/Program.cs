Console.Write("Please enter a number: ");
int number1 = int.Parse(Console.ReadLine());

Console.Write("Please enter a second number: ");
int number2 = int.Parse(Console.ReadLine());

Console.Write("Please enter a third number: ");
int number3 = int.Parse(Console.ReadLine());

int result = number1 + number2 - number3;


Console.WriteLine($"Az eredmeny: {result}");
Console.ReadKey();