using System.Net.WebSockets;

List<BankSzamla> bankSzamlak = new List<BankSzamla>
{
    new ForintBankSzamla(1, new Tulajdonos(1, "Béla", new Lakcim(1, "Anglia", 5900, "London", "Londoni körút", "105/3a")), 14525155, 10000),
    new DevizaBankSzamla(2, new Tulajdonos(2, "Géza", new Lakcim(1, "Magyaroszág", 6722, "Szeged", "Londoni körút", "15/3a")), 45894465, 100000, DevizaTipusEnum.USD)
};

foreach (var bank in bankSzamlak)
{

    bank.Fizetes();
    Console.WriteLine(bank); 
    (bank as IBetet).Kamatozik();
    Console.WriteLine();
    Console.WriteLine(bank);
    Console.WriteLine();
}