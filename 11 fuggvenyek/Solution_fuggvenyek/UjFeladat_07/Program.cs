using IOlibrary;

double wallSize = ExtendentConsole.ReadDouble(1, "Kérem a fal méretét: ");

double amountOfPaint = CalcPaintAmount(wallSize);

double result = CalcMoney(amountOfPaint);

Console.WriteLine($"A Szükséges festék mennyisége: {amountOfPaint} l, ez {result} HUF-ba kerül");

double CalcPaintAmount(double wallSize) => wallSize * 0.15;

double CalcMoney(double amountOfPaint) =>Math.Ceiling( amountOfPaint) * 930;