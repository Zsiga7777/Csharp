Console.Write("Please enter a number: ");
int number = int.Parse(Console.ReadLine());

if (number > -30 && number < 40)
{
    Console.WriteLine($"A(z) {number} szam nagyobb, mint -30 és kisebb, mint 40");
}
else 
{
    Console.WriteLine("A szam nem tartozik a megadott tartomanyba.");
}

Console.ReadKey();