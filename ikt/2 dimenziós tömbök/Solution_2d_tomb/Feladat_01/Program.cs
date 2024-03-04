using Custom.Library.ConsoleExtensions;
Random random = new Random();

int squareSize = ExtendentConsole.ReadInteger(2,"Kérem a 2 dimenziós tömb nagyságát: ");

int[,] matrix = GetMatrix();

Console.Clear();

WriteMatrix(matrix);

// Első feladat
int sumOfMainDiagonal = GetMainDiagonalSum(matrix);
Console.WriteLine($"\nA főátló számainak összege: {sumOfMainDiagonal}");

// Második feladat
int[] secondaryDiagonalElements = GetSecondaryDiagonalElements(matrix);
Console.WriteLine($"\nA mellékátló elemei:");
WriteArray(secondaryDiagonalElements);

// Harmadik feladat
Console.WriteLine("\n\nA főátló feletti elemek: ");
WriteitemsAboveMainDiagonal(matrix);

// Negyedik feladat
Console.WriteLine("\nA főátló alatti elemek: ");
WriteitemsBelowMainDiagonal(matrix);

// Ötödik feladat
int largestNumberBelowSecondaryDiagonal = GetLargestElementBelowSecondaryDiagonal(matrix);
Console.WriteLine($"\nA legnagyob szám a mellékátló alatt: {largestNumberBelowSecondaryDiagonal}");

// Hatodik feladat
int smallestNumberBelowSecondaryDiagonal = GetSmallestElementAboveSecondaryDiagonal(matrix);
Console.WriteLine($"\nA legkisebb szám a mellékátló felett: {smallestNumberBelowSecondaryDiagonal} ");


int[,] GetMatrix()
{
    int[,] matrix = new int[squareSize, squareSize];
    int temp = 0;

    for (int i = 0; i < squareSize; i++)
    {
        for (int j = 0; j < squareSize; j++)
        {
           temp = random.Next(500);
            matrix[i, j] = temp;
        }
    }

    return matrix;
}

void WriteMatrix(int[,] matrix)
{ 
    for (int i = 0;i < squareSize; i++)
    {
        for(int j = 0;j < squareSize; j++)
        {
            Console.Write($"{matrix[i, j]}\t");
        }
        Console.WriteLine();
    }
}

int GetMainDiagonalSum(int[,] matrix)
{
    int result = 0;
    for (int i = 0; i < squareSize; i++)
    { 
        for (int j = 0;j < squareSize; j++)
        {
            if (i == j)
            { 
                result += matrix[i, j];
            }
        }
    }

    return result;
};

int[] GetSecondaryDiagonalElements(int[,] matrix)
{
    int[] result = new int[squareSize];
    for (int i = 0; i < squareSize; i++)
    { 
        for(int j = 0; j < squareSize; j++)
        {
            if (j == (squareSize - i-1))
            {
                result[i] = matrix[i, j];
            }
        }
    }

    return result;
}

void WriteitemsAboveMainDiagonal(int[,] matrix)
{ 
    for (int i = 0;i < squareSize; i++)
    {
        for (int j = 0; j < i; j++)
        {
            Console.Write("\t");
        }
        for (int k = i + 1; k < squareSize; k++)
        {
            Console.Write($"{matrix[i,k]}\t");
        }
        Console.WriteLine();
    }
}

void WriteitemsBelowMainDiagonal(int[,] matrix)
{
    for (int i = 0; i < squareSize; i++)
    {
        
        for (int j = 0; j < i; j++)
        {
            Console.Write($"{matrix[i, j]}\t");
        }
        Console.WriteLine();
    }
}

void WriteArray(int[] array)
{
    foreach (var item in array)
    {
        Console.Write($"{item}, ");
    }
}

int GetLargestElementBelowSecondaryDiagonal(int[,] matrix)
{
    int result = 0;
    for (int i = 0; i < squareSize ; i++) 
    { 
        for (int j = squareSize-1; j > 0; j--)
        {
            if (j > (squareSize-i-1)) 
            {
                if (matrix[i, j] > result)
                { 
                    result = matrix[i,j];
                }
            }
        }
    }

    return result;
}

int GetSmallestElementAboveSecondaryDiagonal(int[,] matrix)
{
    int result = matrix[0,0];
    for (int i = 0; i < squareSize; i++)
    {
        for (int j = 0; j < squareSize; j++)
        {
            if (j < (squareSize - i-1))
            {
                if (matrix[i, j] < result)
                {
                    result = matrix[i, j];
                }
            }
        }
    }

    return result;
}