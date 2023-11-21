using IOlibrary;

const double hufToEur = 380.63;
const double jpyToEur = 0.75;
const double usdToEur = 0.8;
const double chfToEur = 0.55;

double huf = ExtendentConsole.ReadDouble("Kérek egy pénzösszeget forintban: ");

double eur = ConvertMoneyUnit(huf, hufToEur);

string unit = ReadUnit();

double result = unit switch
{
    "JPY" => ConvertMoneyUnit(eur, jpyToEur),
    "USD" => ConvertMoneyUnit(eur, usdToEur),
    "CHF" => ConvertMoneyUnit(eur, chfToEur),
};

Console.WriteLine($"A megadott mennyiségű forint euróban:{eur} EUR, és a kiválasztott pénznemben: {result} {unit}");


double ConvertMoneyUnit(double amountOfmoney, double convertRatio) => amountOfmoney / convertRatio;

string ReadUnit()
{
    string text = string.Empty;
    do
    { 
        text = ExtendentConsole.ReadString("Kérek egy mértékegységet(JPY, USD vagy CHF): ").ToUpper();

    }
    while(text !="JPY" && text != "USD" && text != "CHF");
    return text;
};