using MessageToDifferentSystems;

Console.WriteLine("Kérem a küldendő üzenetet: ");
string message = Console.ReadLine();

Console.WriteLine("\nKérem a cél rendszer számát(1- android, 2- ios, 3- windows): ");
int selectedSystemNumber = int.Parse(Console.ReadLine());

BasicSystem result = selectedSystemNumber switch
{
    1 => new Android { Message = message },
    2 => new Ios { Message = message },
    3 => new Windows { Message = message },
};

result.SendMessage();