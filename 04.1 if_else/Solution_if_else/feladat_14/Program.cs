Console.Write("Please enter a number: ");
int x = int.Parse(Console.ReadLine());

Console.Write("Please enter another number: ");
int y = int.Parse(Console.ReadLine());

Console.Write("Please enter a third number: ");
int z = int.Parse(Console.ReadLine());

if (x % z ==0 && x % y == 0 )
{
    Console.WriteLine($"{x} oszthato {z}-vel es {y}-al");
}
else if (x % y == 0)
{
    Console.WriteLine($"{x} csak {y}-al oszthato.");
}
else if (x % z == 0)
{
    Console.WriteLine($"{x} csak {z}-vel oszthato.");
}    
else
{
    Console.WriteLine($"{x} egyikkel sem osztaho.");
}

Console.ReadKey();