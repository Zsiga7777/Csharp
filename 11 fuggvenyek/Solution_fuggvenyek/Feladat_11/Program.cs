using IOlibrary;

const int BASE_WORKING_HOURS = 40;

Worker worker = new Worker();

worker.workedHours = ExtendentConsole.ReadInteger(0, 168, "Kérem a ledolgozott óraszámát: ");
worker.name = ExtendentConsole.ReadString("Kérem a nevét: ");


worker.payment = PaymentCalculator(BASE_WORKING_HOURS);
int overPayment = worker.workedHours > BASE_WORKING_HOURS ? PaymentCalculator(worker.workedHours - BASE_WORKING_HOURS, 1500) : 0;

worker.payment += overPayment; 

Console.WriteLine($"A dolgozó neve:{worker.name}\nA dolgozó által ledolgozott órák száma:{worker.workedHours}\n" +
    $"A dolgozó fizetése:{worker.payment}");




int PaymentCalculator(int workedHour , int payment = 1000) => workedHour * payment;
