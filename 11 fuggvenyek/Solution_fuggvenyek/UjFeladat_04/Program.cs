using IOlibrary;

Random rnd = new Random();

int starter = rnd.Next(0, 10);
int ender = rnd.Next(40, 51);
int randomNumber = rnd.Next(starter, ender);

int result = GuessTheNumber(randomNumber);

Console.WriteLine($"A kitalálandó számot({randomNumber}) {result} tippből sikerült kitalálni");

int GuessTheNumber(int number)
{
    int tries = 0;
    int input = 0;
    do
    {
        input = ExtendentConsole.ReadInteger("Kérek egy számot: ");

        if (input < number)
        {
            Console.WriteLine("A kitalálandó szám nagyobb ");
        }
        else if(input > number)
        {
            Console.WriteLine("A kitalálandó szám kisebb ");
        } 
        
        tries++;
    } while (input != number);

    return tries;

}