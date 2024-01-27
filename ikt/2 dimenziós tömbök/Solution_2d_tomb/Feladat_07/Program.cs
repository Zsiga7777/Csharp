Random random = new Random();
const int NUMBEROFROWS = 7;
const int NUMBEROFCOLUMNS = 4;

double[,] weatherDatas = GetWeatherData();

// Feladat 1
WriteWeatherData(weatherDatas);

//feladat 2
double[] averageRainAmount = OrderDailyAverageRain(weatherDatas);
Console.WriteLine("\nA napi csapadékok átlaga növekvő sorrendben:");
WriteArray(averageRainAmount);

// feladat 3
string worstDay = GetDayWithSmallestAmount(weatherDatas);
string bestDay = GetDayWithLargestAmount(weatherDatas);
Console.WriteLine($"\n{worstDay} esett a legkevesebb, {bestDay} esett a legtöbb csapadék");

// feladat 4
string dayWithTheLargestAmountOfMorningRain = GetDayWithLargestAmountMorningRain(weatherDatas);
Console.WriteLine($"\n{dayWithTheLargestAmountOfMorningRain} esett a legtöbb eső reggel") ;

// feladat 5
string dayWithTheLargestAmountOfRain622 = GetDayWithLargestAmountRainfrom6To22(weatherDatas);
Console.WriteLine($"\n{dayWithTheLargestAmountOfRain622} esett a legtöbb eső 6 és 22 előtt");

double[,] GetWeatherData()
{
    double[,] results = new double[NUMBEROFROWS, NUMBEROFCOLUMNS];
    int temp = 0;
    double result;

    for (int i = 0; i < NUMBEROFROWS; i++)
    { 
     for (int j = 0; j < NUMBEROFCOLUMNS; j++)
        {
            temp = random.Next(10, 100);
            result = random.Next(0,5) +(double) temp/(double)100;
            result = (Math.Round(result * 100)) / 100;
            results[i,j] = result;
            if (j == 3)
            {
                results[i,j] = (Math.Round(((results[i,0] + results[i, 1] + results[i, 2])/(double)3)*100))/100;
            }
        }
    }

    return results;
}

void WriteWeatherData(double[,] data)
{
    for (int i = 0; i < NUMBEROFROWS; i++)
    {
         
        for (int j = 0; j < NUMBEROFCOLUMNS; j++)
        {
            Console.Write($"{data[i,j],-4} ");
        }
       Console.WriteLine($"\t{i + 1}. nap");
    }
}

double[] OrderDailyAverageRain(double[,] data)
{
    double[] results = new double[NUMBEROFROWS];
    double temp = 0;
    for (int i = 0; i < NUMBEROFROWS; i++)
    {
        results[i] = data[i,3];
    }

    for (int i = 0;i < NUMBEROFCOLUMNS; i++)
    {
        for (int j = i+1; j < NUMBEROFROWS; j++)
        {
            if (results[i] > results[j])
            { 
                temp = results[i];
                results[i] = results[j];
                results[j] = temp;
            }
        }
    }

    return results;
}

void WriteArray(double[] data)
{
    foreach (var item in data)
    {
        Console.WriteLine(item);
    }
}

string GetDayWithSmallestAmount(double[,] data)
{
    string result = "";
    double temp = data[0, 0] + data[0, 1] + data[0, 2];

    for (int i = 0;i < NUMBEROFROWS ; i++) 
    {
        if (data[i, 0] + data[i, 1] + data[i,2] < temp)
        {
            temp = data[i, 0] + data[i, 1] + data[i, 2];
            result = $"{i+1}. nap";
        }
    }
    return result;
}

string GetDayWithLargestAmount(double[,] data)
{
    string result = "";
    double temp =0;

    for (int i = 0; i < NUMBEROFROWS; i++)
    {
        if (data[i, 0] + data[i, 1] + data[i, 2] > temp)
        {
            temp = data[i, 0] + data[i, 1] + data[i, 2];
            result = $"{i + 1}. nap";
        }
    }
    return result;
}

string GetDayWithLargestAmountMorningRain(double[,] data)
{
    string result = "";
    double temp = 0;

    for (int i = 0; i < NUMBEROFROWS; i++)
    {
        if (data[i, 0] > temp)
        {
            temp = data[i, 0] ;
            result = $"{i + 1}. nap";
        }
    }
    return result;
}

string GetDayWithLargestAmountRainfrom6To22(double[,] data)
{
    string result = "";
    double temp = 0;

    for (int i = 0; i < NUMBEROFROWS; i++)
    {
        if (data[i, 1] + data[i,2] > temp)
        {
            temp = data[i, 1] + data[i,2];
            result = $"{i + 1}. nap";
        }
    }
    return result;
}