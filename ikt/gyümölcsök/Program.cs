using Custom.Library.ConsoleExtensions;

const int NUMBEROFFRUITS = 3;

Fruit[] fruits = GetFruits();

Console.Clear();

double amountOfFruits = fruits.Sum(f => f.Amount);
Console.WriteLine($"Az összes gyümölcs mennyisége: {amountOfFruits:F2} kg");

Console.WriteLine("\nA készlet értéke gyümölcs fajtánként: ");
WriteStockValues(fruits);

double fullStockValue = fruits.Sum(fruit => fruit.StockValue);
Console.WriteLine($"\nA teljes készlet értéke: {fullStockValue:F2} Ft");

double largestPrice = fruits.Max(f => f.Price);
Fruit[] mostExpensiveFruits = SortFruitByPrice(fruits, largestPrice);
Console.WriteLine("\nA legdrágább gyümölcs(ök): ");
WriteMostExpensiveFruit(mostExpensiveFruits);

double smallestAmunt = fruits.Min(fruit => fruit.Amount);
Fruit[] smallestAmuntFruits = SortFruitByAmount(fruits, smallestAmunt);
Console.WriteLine("\nA legkisebb mennyiségű gyümölcs(ök): ");
WriteSmallestAmountFruit(smallestAmuntFruits);

Fruit[] fruitsLessThan100Kg = fruits.Where(fruit => fruit.Amount < 100).ToArray();
Console.WriteLine("\n100kg alatti gyümölcs(ök): ");
WriteFruits(fruitsLessThan100Kg);

bool priceHigherThan1500 = fruits.Any(fruit => fruit.Price > 1500);
Console.WriteLine($"\nVan-e 1500 Ft feletti egységárral rendelkező gyümölcs: {(priceHigherThan1500 ? "igen":"nem")} ");

Fruit[] GetFruits()
{
    Fruit[] fruits = new Fruit[NUMBEROFFRUITS];
    string fruitName = "";
    double amount = 0;
    double price = 0;

    for (int i = 0; i < NUMBEROFFRUITS; i++)
    {
        fruitName = ExtendentConsole.ReadString("Kérem a gyümölcs nevét: ");
        amount = ExtendentConsole.ReadDouble(0, "Kérem a gyümölcs menyniségét(kg-ban): ");
        price = ExtendentConsole.ReadDouble(0, "Kérem a gyümölcs árát: ");

        fruits[i] = new Fruit(fruitName, amount, price);
    }

    return fruits;
}

void WriteStockValues(Fruit[] fruits)
{
    foreach (var fruit in fruits)
    {
        Console.WriteLine($"A gyümölcs neve: {fruit.FruitName}, a készlet értéke: {fruit.StockValue:F2} Ft");
    }
}

Fruit[] SortFruitByPrice(Fruit[] fruits, double price) => fruits.Where(fruit => fruit.Price == price).ToArray();

void WriteMostExpensiveFruit(Fruit[] fruits)
    {
    foreach (var fruit in fruits)
    {
        Console.WriteLine($"A gyümölcs neve: {fruit.FruitName}, az ára: {fruit.Price:F2} Ft");
    }
}
Fruit[] SortFruitByAmount(Fruit[] fruits, double amount) => fruits.Where(fruit => fruit.Amount == amount).ToArray();

void WriteSmallestAmountFruit(Fruit[] fruits)
{
    foreach (var fruit in fruits)
    {
        Console.WriteLine($"A gyümölcs neve: {fruit.FruitName}, a mennyisége: {fruit.Amount:F2} Kg");
    }
}

void WriteFruits(Fruit[] fruits)
{
    foreach (var fruit in fruits)
    {
        Console.WriteLine(fruit);
    }
}