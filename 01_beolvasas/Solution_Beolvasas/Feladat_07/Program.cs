Console.Write("Please enter your favourite car's brand: ");

string carBrand= Console.ReadLine();

Console.Write("Please enter your favourite car's model: ");

string carModel = Console.ReadLine();

Console.Write("Please enter your favourite car's type: ");

string carType = Console.ReadLine();

Console.Write("Please enter your favourite car's cylinder capacity: ");

double carCylinderCapacity = double.Parse(Console.ReadLine());

Console.Write("Please enter your favourite car's debut year: ");

int carYear = int.Parse(Console.ReadLine());

Console.WriteLine($"Márka: {carBrand}\nModell: {carModel}\nTípus:{carCylinderCapacity} {carType}\nMegjelenés év:{carYear}");

Console.ReadKey();