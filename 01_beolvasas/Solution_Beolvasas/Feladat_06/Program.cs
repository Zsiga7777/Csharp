Console.Write("Please enter your favourite movie's title: ");

string movieName = Console.ReadLine();

Console.Write("Please enter your favourite movie's debut year: ");

int movieYear = int.Parse(Console.ReadLine());

Console.Write("Please enter your favourite movie's director: ");

string movieDirector = Console.ReadLine();

Console.Write("Please enter your favourite movie's lead actor: ");

string movieLeadActor = Console.ReadLine();

Console.WriteLine($"{movieYear}-ban {movieDirector} rendezésében megjelent a/az {movieName} című film {movieLeadActor} főszereplésével!");

Console.ReadKey();