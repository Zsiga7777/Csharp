using IOlibrary;

const double hufToEur = 380.63;
const double jpyToEur = 0.75;
const double usdToEur = 0.8;
const double chfToEur = 0.55;

double huf = ExtendentConsole.ReadDouble(0.0,"Kérek egy pénzösszeget forintban: ");

double eur = ConvertMoneyUnit(huf, hufToEur);

Currency currency = ReadUnit();

double result = currency switch
{
    Currency.JPY => ConvertMoneyUnit(eur, jpyToEur),
    Currency.USD => ConvertMoneyUnit(eur, usdToEur),
    Currency.CHF => ConvertMoneyUnit(eur, chfToEur),
};

Console.WriteLine($"A megadott mennyiségű forint euróban:{eur} EUR, és a kiválasztott pénznemben: {result} {currency}");


double ConvertMoneyUnit(double amountOfmoney, double convertRatio) => amountOfmoney / convertRatio;

Currency ReadUnit()
{
    bool isCurrency = false;
    Currency currency;
    do
    { 
       string input  = ExtendentConsole.ReadString("Kérek egy mértékegységet(JPY, USD vagy CHF): ");
        isCurrency = Enum.TryParse<Currency>(input, true, out currency);
    }
    while(!isCurrency);
    return currency;
};