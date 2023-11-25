using IOlibrary;

Worker worker = new Worker();

worker.workedHours = ExtendentConsole.ReadInteger(0, 168, "Kérem a ledolgozott óraszámát: ");
worker.name = ExtendentConsole.ReadString("Kérem a nevét: ");
worker.payment = PaymentCalculator(worker.workedHours);

Console.WriteLine($"A dolgozó neve:{worker.name}\nA dolgozó által ledolgozott órák száma:{worker.workedHours}\n" +
    $"A dolgozó fizetése:{worker.payment}");




int PaymentCalculator(int workedHour = 40, int normalPayment = 1000, int extraPayment = 1500)
{
    int payment = 0;

    if (workedHour > 40 )
    {
        payment = ((workedHour - 40) * extraPayment) + 40 * normalPayment;
    }
    else
    {
        payment = workedHour * normalPayment;
    }

    return payment;
};