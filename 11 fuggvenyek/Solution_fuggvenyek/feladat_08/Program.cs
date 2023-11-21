using System.Drawing;
using System.Transactions;
using CustomLibrary;
using IOlibrary;

Point a = GetPoint();
Point b = GetPoint();

int x = Math.Abs(a.X-b.X);
int y = Math.Abs(a.Y-b.Y);

double result = MathExtensions.PythagoreanTheorem(x, y);

Console.WriteLine($"Az eredmény: {result}");

Point GetPoint()
{ 
    Point point = new Point();
    point.X = ExtendentConsole.ReadInteger("Kérek egy x értéket: ");
    point.Y = ExtendentConsole.ReadInteger("Kérek egy y értéket: ");

    return point;
};