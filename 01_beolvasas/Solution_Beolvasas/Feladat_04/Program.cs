Console.Write("Please enter your name: ");

string name = Console.ReadLine();

Console.Write("Please type a letter: ");

char letter = Console.ReadKey().KeyChar;

Console.WriteLine($" {name} on a/az {letter} billentyut nyomta meg!");

Console.ReadKey();