Shape shape = new Square(10);

shape = new Rectangle(10, 20);
PrintShape(shape);
//nem lehet, mivel a circle osztály nem valósítja meg az IShape interfacet
//IShape circle = new Circle(10);

void PrintShape(IShape shape)
{
    if (shape is Square)
    {
        Console.WriteLine("negyzet");
        Console.WriteLine(shape);
    }
    else if (shape is Rectangle)
    {
        Console.WriteLine("téglalap");
        Console.WriteLine(shape);
    }
    else
    {
        Console.WriteLine("ismeretlen alakzat");
    }
}