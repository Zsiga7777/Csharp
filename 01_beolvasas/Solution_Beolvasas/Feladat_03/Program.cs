using System.Globalization;

Console.Write("Please enter your name: ");

string name = Console.ReadLine();

Console.Write("Please enter your height: ");

double height = double.Parse(Console.ReadLine());

Console.WriteLine($"{name} az on magassaga {height}m.");


var age =double.Parse(Console.ReadLine(), new CultureInfo("en-EN"));
Console.WriteLine($"kor: {age}");