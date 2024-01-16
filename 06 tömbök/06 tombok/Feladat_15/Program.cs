using Custom.Library.ConsoleExtensions;


const int NUMBEROFTRUCKS = 5;
Random random = new Random();

Truck[] trucks = GetTrucks();

Console.Clear();

WriteTrucks(trucks);

double sumWeight = trucks.Sum(x => x.Weight);
Console.WriteLine($"\nA kamionok össztömege: {sumWeight:F2} t");

double averageWeight = trucks.Average(x => x.Weight);
Console.WriteLine($"\nA kamionok átlag súlya: {averageWeight:F2}");

double largestWeight = trucks.Max(x => x.Weight);
Truck[] heaviestTruck = trucks.Where(x => x.Weight == largestWeight).ToArray();
Console.WriteLine("\nA legnehezebb kamion(ok): ");
WriteTrucksPlate(heaviestTruck);

bool weight10Tons = trucks.Any(t => t.Weight == 10);
Console.WriteLine($"\nVolt-e 10 tonnás kamion? {(weight10Tons? "igen":"nem")}");

Truck[] trucksHeavierThan10t = trucks.Where(t => t.Weight > 10).ToArray();
Console.WriteLine("\nA 10 tonnánál nehezebb kamion(ok): ");
WriteTrucksPlate(trucksHeavierThan10t);

double smallestWeight = trucks.Min(t => t.Weight);
int numberOfLightestTruck = GetLightestTruckIndex(trucks, smallestWeight);
Console.WriteLine($"\nA legkönnyebb kamion {numberOfLightestTruck}-ként haladt át.");

Truck[] GetTrucks()
{
    Truck[] trucks = new Truck[NUMBEROFTRUCKS];
    string plate = "";
    double weight = 0;

    for (int i = 0; i < NUMBEROFTRUCKS; i++)
    {
        do
        {
            weight = random.Next(3, 40) + random.NextDouble();
        } 
        while( weight < 3.5);
        
        plate = ExtendentConsole.ReadString("Kérem a kamion rendszmámát:");

        trucks[i] = new Truck(plate, weight);
    }

    return trucks;
}

void WriteTrucks(Truck[] trucks)
{
    foreach (var truck in trucks)
    {
        Console.WriteLine(truck);
    }
}

void WriteTrucksPlate(Truck[] trucks)
{
    foreach (var truck in trucks)
    {
        Console.WriteLine(truck.Plate);
    }
}

int GetLightestTruckIndex(Truck[] trucks, double weight)
{
    int numberOfTruck = 0;
    for (int i = 0; i < NUMBEROFTRUCKS; i++)
    {
        if (trucks[i].Weight == weight)
        {
            numberOfTruck = i + 1; 
            break;
        }
    }
    return numberOfTruck;
}