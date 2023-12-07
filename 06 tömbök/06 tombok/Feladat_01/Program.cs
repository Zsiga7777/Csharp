Random rnd = new Random();

int[] array = await GetIntArrayAsync(10); //await, bevárjuk, hogy a függvény lefusson

Console.WriteLine($"Generated array: ");
ReversePrintArrayToConsole( array );

int sum = GetArraySum( array );
Console.WriteLine($"Sum of the array: {sum}");

double avarage =(double) sum/ array.Length;
Console.WriteLine($"Avarage of the array : {avarage:F2}");

Console.WriteLine("Even elements of the array: ");
int[] evenNumbersArray = GetEvenNumbersFromArray(array);
PrintArrayToConsole( evenNumbersArray );


int numberOfTwoDigitNumebr = GetTwoDigitNumbers(array);
Console.WriteLine($"Number of numbers grater then 9 int the array: {numberOfTwoDigitNumebr}");

Console.WriteLine($"Single digit elements  int the array: ");
int[] singleElementsOfTheArray = array.Where(x => x < 10).ToArray();
PrintArrayToConsole( singleElementsOfTheArray );

int oddNumbersSum = CalculateOddNumbersSumOfArray(array); 
//array.Where(x => x % 2 == 1).Sum(x => x);
Console.WriteLine($"Odd numbers sem: {oddNumbersSum}");

int zeroEndedNumbers = array.Count(x => x % 10 ==0);
Console.WriteLine($"Zero ended numbers: {zeroEndedNumbers}");

Console.WriteLine("The array in ascending order: ");
OrderArrayAscending(array);
PrintArrayToConsole(array);

//async -aszinkron függvény( a függvény lefutása bevárható, mivel nem fejeződik be rögtön)
// Task<int[]> - az aszinkron függvény eredménye egy feladat (Task), amelynek az eredménye egy int tipusú tömb lesz amikor befejeződik.
async Task<int[]> GetIntArrayAsync(int arraySize)
{
    int[] array = new int[arraySize];

    for (int i = 0; i < arraySize; i++)
    {
        array[i] = rnd.Next(0,100);
        await Task.Delay(100);
    };
    return array;
}

void ReversePrintArrayToConsole(int[] arrayTiPrint)
{ 
for (int i = arrayTiPrint.Length-1; i  >= 0; i--) {
        Console.WriteLine($"[{i+1}] = {arrayTiPrint[i]}");
    }
}

void PrintArrayToConsole(int[] arrayTiPrint)
{
    for (int i = 0; i < arrayTiPrint.Length;i ++)
    {
        Console.WriteLine($"[{i + 1}] = {arrayTiPrint[i]}");
    }
}

int GetArraySum(int[] array)
{
    int sum = 0;
    foreach (int item in array)
    {
        sum += item;
    }
    return sum;
        }

int[] GetEvenNumbersFromArray(int[] array)
{
    int[] evenNumbers = array.Where(x => x % 2 == 0).ToArray();

    return evenNumbers;
}

/*int GetTwoDigitNumbers(int[] array)
{
    int counter = 0;
    foreach (int number in array)
    {
        if (number > 9)
        { 
            counter++;
        } }
    return counter;
}*/
int GetTwoDigitNumbers(int[] array) => array.Count(x => x > 9);

int CalculateOddNumbersSumOfArray(int[] array)
{
    int sum = 0;

    foreach (int number in array)
    {
        if (number % 2 == 1)
        {
            sum += number;
                };
    };
    return sum;
}

void OrderArrayAscending(int[] array)
{
    int temp = 0;
    for (int i = 0; i < array.Length-1; i++)
    {
        for (int j = i+1; j < array.Length; j++) 
        {
            if (array[j] < array[i])
            {
                temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}