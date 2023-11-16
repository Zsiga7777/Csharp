using IOlibrary;
double celsius = ExtendentConsole.ReadDouble("Kérek egy hőmérsékletet Celsiusban: ");
char goal = ReadChar();
double done = 0.0;

switch (goal)
    {
    case 'F':
    case 'f':
        {
            done = MathExtensions.CelsiusToFahrenheit(celsius);
            Console.WriteLine($"A végeredmény: {done} f");
            break;
        }
    case 'k':
    case 'K':
        {
            done = MathExtensions.CelsiusToKelvin(celsius);
            Console.WriteLine($"A végeredmény: {done} K");
            break;
        }
}
char ReadChar()
{
    char  text ;
    do
    {
        Console.Write($"Kérek egy értéket, amibe szeretné átalakítani(K - Kelvin, F - Fahrenheit): ");
        text =Console.ReadKey().KeyChar;
            }
    while (text == 'k' || text == 'K' || text == 'f' || text == 'F');

    return text;
};