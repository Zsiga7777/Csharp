using IOlibrary;

int workersNumber = ExtendentConsole.ReadInteger(1,int.MaxValue,"Kérem a munkások számát: ");

Worker[] workers = new Worker[workersNumber];


for (int i = 0; i < workers.Length;i++)
{
Worker worker = new Worker();

worker.workedHours = ExtendentConsole.ReadInteger(0, 168, "Kérem a ledolgozott óraszámát: ");
worker.name = ExtendentConsole.ReadString("Kérem a nevét: ");
worker.payment = PaymentCalculator(worker.workedHours);

workers[i] = worker;
Console.Clear();
}



foreach (Worker i in workers)
{
    Console.WriteLine($"A dolgozó neve:{i.name}\nA dolgozó által ledolgozott órák száma:{i.workedHours}\n" +
    $"A dolgozó fizetése:{i.payment}\n");
}





int PaymentCalculator(int workedHour = 40, int normalPayment = 1000, int extraPayment = 1500)
{
    int payment = 0;

    if (workedHour > 40)
    {
        payment = ((workedHour - 40) * extraPayment) + 40 * normalPayment;
    }
    else
    {
        payment = workedHour * normalPayment;
    }

    return payment;
};