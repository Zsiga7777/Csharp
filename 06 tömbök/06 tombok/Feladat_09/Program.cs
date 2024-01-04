using Custom.Library.ConsoleExtensions;

const int NUMBER_OF_CARS = 10;

Car[] cars = GetCars();

Console.Clear();

Car[] speedingCars = cars.Where(car => car.Speed > 90).ToArray();
WriteCars(speedingCars);

int sumPenalties = speedingCars.Sum(car => car.Penalty);
Console.WriteLine($"\nA hatóságok összesen: {sumPenalties} Ft büntetést szedtek össze.");

int biggestSpeed = cars.Max(car => car.Speed);
Car fastestCar = GetFastestCar(cars,biggestSpeed);
Console.WriteLine($"\nA leggyorsabb autó rendszáma: {fastestCar.Plate}, sebessége: {fastestCar.Speed} km/h");

int numberOfNotSpeedingCars = cars.Count(car => car.Speed <= 90);
double percentOfCars =(double) numberOfNotSpeedingCars / ((double)NUMBER_OF_CARS / 100);
Console.WriteLine($"\n{numberOfNotSpeedingCars} közlekedett szabályosan, ez {percentOfCars:F2} %-a az áthaladó autóknak.");

bool carWith60kmh = cars.Any(car => car.Speed == 60);
Console.WriteLine($"\nVolt-e 60-al menő autó: {(carWith60kmh ? "igen" : "nem")}");

Car[] GetCars()
{
    Car[] cars = new Car[NUMBER_OF_CARS];

    for (int i = 0; i < NUMBER_OF_CARS; i++)
    { 
        int speed = ExtendentConsole.ReadInteger(0, int.MaxValue, "Kérem az autó sebességét: ");
        string plate = ExtendentConsole.ReadString("Kérem az autó rendszámát: ");
        int penalty = GetPenalty(speed);

        cars[i] = new Car(speed, plate, penalty);
    }

    return cars;
}

int GetPenalty(int speed)
{ 
    int penalty = speed switch
     {
         > 110 => 30000,
         > 100 => 20000,
         > 90 => 10000,
         _ => 0
     };
    return penalty;
}

void WriteCars(Car[] speedingCars)
{ 
    foreach (Car car in speedingCars)
    {
        Console.WriteLine($"{car}");
    }
}

Car GetFastestCar(Car[] cars, int biggestSpeed )
{
    Car resultCar = new Car();
    foreach (Car car in cars )
    {
        if(car.Speed == biggestSpeed) {
        resultCar = car;
            break;
        }
    }
    return resultCar;

}