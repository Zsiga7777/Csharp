Console.Write("Please enter your favourite band's name: ");

string bandName = Console.ReadLine();

Console.Write("Please enter your favourite song's name: ");

string songName = Console.ReadLine();

Console.Write("Please enter your favourite song's lenght: ");

double songLenght = double.Parse(Console.ReadLine());

Console.WriteLine($"Az ön kedvenc együttesének {bandName} a legjobb zeneszáma {songName} melynek hossza {songLenght} perc !");

Console.ReadKey();