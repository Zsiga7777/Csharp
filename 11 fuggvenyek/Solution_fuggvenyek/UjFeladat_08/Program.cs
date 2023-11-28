using IOlibrary;

const int TAX = 1000;

double length = ExtendentConsole.ReadDouble(1, "Kérem a telek hosszát: ");
double width = ExtendentConsole.ReadDouble(1, "Kérem a telek szélességét: ");

double result = length < 30 && width < 20 ? TaxCalc(TAX,length,width)*0.75 : TaxCalc(TAX, length, width);

Console.WriteLine($"Az adó:{result} Ft");
double TaxCalc(int tax, double length, double width) => length * width * tax;