Console.Write("Please enter a month name: ");
string month = Console.ReadLine().ToLower();

int? monthNumber = month switch
{
    "januar" => 1,
    "februar" => 2,
    "marcius" => 3,
    "aprilis" => 4,
    "majus" => 5,
    "junius" => 6,
    "julius" => 7,
    "augusztus" => 8,
    "szeptember" => 9,
    "oktober" => 10,
    "november" => 11,
    "december" => 12,
    _ => null,
};
if (monthNumber == null)
{
    Console.WriteLine("Ilyen hónap nincs");
}
else
{
    Console.WriteLine(monthNumber);
}


Console.ReadKey();