using IOlibrary;

double point = ExtendentConsole.ReadDouble(1,100, "Kérem az elért százalékot: ");

double result = GradeCalculator(point);

Console.WriteLine($"Az elért jegy: {result}");


int GradeCalculator(double reachedPoint)
{
    int result = reachedPoint switch
        {
            <50 => 1,
            <60 => 2,
            <70 => 3,
            <85 => 4,
             _ => 5
    };
    return result;
}