double celsius = ExtendentConsole.ReadDouble("Kérek egy hőmérsékletet Celsiusban: ");
string goal = ReadChar().ToString().ToLower();

double result = goal switch
{
    "f" => MathExtensions.CelsiusToFahrenheit(celsius),
    "k" => MathExtensions.CelsiusToKelvin(celsius),
};


Console.WriteLine($"\nA végeredmény: {result} {goal}");

char ReadChar()
{
    char  text ;
    do
    {
        Console.Write($"Kérek egy értéket, amibe szeretné átalakítani(K - Kelvin, F - Fahrenheit): ");
        text =Console.ReadKey().KeyChar;
            }
    while (text != 'k' && text != 'K' && text != 'f' && text != 'F');

    return text;
};