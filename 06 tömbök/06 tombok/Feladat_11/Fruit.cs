internal class Fruit
{
    public string FruitName { get; set; }
    public double Amount { get; set; }

    public double Price { get; set; }

    public double StockValue => Price * Amount;

    public Fruit() { }

    public Fruit(string fruitName, double amount, double price)
    {
        FruitName = fruitName;
        Amount = amount;
        Price = price;
    }
    public override string ToString()
    {
        return $"A gyümölcs neve: {FruitName}, mennyisége: {Amount:F2} kg, ára:{Price:F2} Ft, készletének értéke: {StockValue:F2} Ft";
    }
}