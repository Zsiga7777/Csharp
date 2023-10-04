int number1 = 0;
int numberOfTries = 0;
int result = 0;
bool isNumber1 = false;


do
{
    numberOfTries++;

    Console.Write("Kérek egy számot: ");
    string input = Console.ReadLine();

    isNumber1 = int.TryParse(input, out number1);

    result += number1 ;

    Console.WriteLine($"Jelenleg {numberOfTries} leütésnél tart és a jelenlegi összeg {result}");
}
while (!isNumber1 || result<100);
