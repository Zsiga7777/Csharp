using Custom.Library.ConsoleExtensions;

int squareSize = ExtendentConsole.ReadInteger(1,"Kérem a 2 dimenziós tömb nagyságát: ");

int[,] matrix = GetMatrix();


// Első feladat
int sumOfMainDiagonal = GetMainDiagonalSum(matrix);
Console.WriteLine($"A főátló számainak összege: {sumOfMainDiagonal}");

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
int largestNumberBelowSecondaryDiagonal = matrix[squareSize-1, squareSize-1];
Console.WriteLine($"\nA legnagyob szám a mellékátló alatt: {largestNumberBelowSecondaryDiagonal}");

// Hatodik feladat
int smallestNumberAboveSecondaryDiagonal = matrix[0, 0];
Console.WriteLine($"\nA legkisebb szám a mellékátló felett: {smallestNumberAboveSecondaryDiagonal}");


int[,] GetMatrix()
{
    int[,] matrix = new int[squareSize, squareSize];
    int szamlalo = 0;

    for (int i = 0; i < squareSize; i++)
    {
        for (int j = 0; j < squareSize; j++)
        {
            szamlalo++;
            matrix[i, j] = szamlalo;
        }
    }

    return matrix;
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
            Console.Write("      ");
        }
        for (int k = i + 1; k < squareSize; k++)
        {
            Console.Write($"[{i}, {k}]");
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
            Console.Write($"[{i}, {j}]");
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