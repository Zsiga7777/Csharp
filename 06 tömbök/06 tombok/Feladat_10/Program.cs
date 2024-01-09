using Custom.Library.ConsoleExtensions;


const int NUMBEROFCARS = 10;
Car[] cars = GetCars();

Console.Clear();

Car[] carWithHighAmountOfPetrol = cars.Where(car => car.AmountOfFuel > 40).ToArray();
Console.WriteLine("A 40 liter felett vásárolt autók:");
WriteCars(carWithHighAmountOfPetrol);

double allBoughtfuel = cars.Sum(car => car.AmountOfFuel);
Console.WriteLine($"\nAz összesen vásárolt üzemanyag: {allBoughtfuel}");

double largestAmountOfFuel = cars.Max(car => car.AmountOfFuel);
Car[] carsWithTheMostFuel= GetCarsWithTheAmountfuel(cars, largestAmountOfFuel);
Console.WriteLine("\nA legtöbb üzemenyagot vásárolt autó(k): ");
WriteCars(carsWithTheMostFuel);

double smallestAmountOfFuel = cars.Min(car => car.AmountOfFuel);
Car[] carWithTheLessAmountOfFuel=GetCarsWithTheAmountfuel(cars, smallestAmountOfFuel);
Console.WriteLine("\nA legkevesebb üzemenyagot vásárolt autó(k): ");
WriteCars(carWithTheLessAmountOfFuel);


int numberOfCarsUnder30Liter = cars.Count(car => car.AmountOfFuel < 30);
Console.WriteLine($"\nA 30 liter alatt vásárolt autók száma: {numberOfCarsUnder30Liter}");

bool anyCarWith50Liter = cars.Any(car => car.AmountOfFuel == 50);
Console.WriteLine($"\nVolt-e olyan autó, ami 50 litert tankolt: {(anyCarWith50Liter ? "igen" : "nem")}");
Car[] GetCars()
{
    Car[] cars = new Car[NUMBEROFCARS];
    string plate = "";
    double amountOfPetrol = 0;
    for (int i = 0; i < NUMBEROFCARS; i++)
    {
        plate = ExtendentConsole.ReadString("Adja meg a rendszámot: ");
        amountOfPetrol = ExtendentConsole.ReadDouble(0,"Kérem a tankolt mennyiséget: ");

        cars[i] = new Car(plate, amountOfPetrol);
    }

    return cars;
}

void WriteCars(Car[] cars)
{
    Console.WriteLine("");
    foreach (Car car in cars)
    {
        Console.WriteLine(car);
    }
}

Car[] GetCarsWithTheAmountfuel(Car[] cars, double amount) => cars.Where(x => x.AmountOfFuel == amount).ToArray();