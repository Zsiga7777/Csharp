using Custom.Library.ConsoleExtensions;
using System.Data;

const int NUMBER_OS_WORKERS = 5;

Worker[] workers = GetWorkers();

Console.WriteLine("\n\nDolgozók:  ");
PrintWorkerOnConsole(workers);

Console.WriteLine("\n\nHozzájárulások: ");
PrintToConsoleContribution(workers);

Worker[] GetWorkers()
{
    Worker[] workers = new Worker[NUMBER_OS_WORKERS];
    Worker worker = null;

    for (int i = 0; i < NUMBER_OS_WORKERS; i++)
    {
        string name = ExtendentConsole.ReadString("Adja meg a dolgozó nevét: ");

        workers[i] = new Worker(name);
    }
    return workers;
}

void PrintWorkerOnConsole(Worker[] workers)
{
    Console.WriteLine($"\t  jan\t   feb\t    már\t\tápr\tmáj\tjun\tjul\t  aug\t  szep\t   okt\t\tnov\tdec");
    foreach (Worker worker in workers)
    {
        Console.WriteLine(worker);
    }
}

void PrintToConsoleContribution(Worker[] workers)
{
    Console.WriteLine($"\t\tSZJA\t\tTB\t\tNYHJ");
    foreach (Worker worker in workers) {
        Console.WriteLine($"{worker.Name.PadRight(8)}\t{worker.SZJA:F2}\t{worker.TB:F2}\t{worker.NYHJ:F2}");
            }
}