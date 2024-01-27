using Custom.Library.ConsoleExtensions;
Random random = new Random();

int squareSizeWidth = ExtendentConsole.ReadInteger(1, "Kérem a 2 dimenziós tömb hosszát: ");
int squareSizeHeight = ExtendentConsole.ReadInteger(1, "Kérem a 2 dimenziós tömb magasságát: ");

int[,] matrix = GetMatrix();

Console.WriteLine("\nEredeti tömb: ");
WriteMatrix(matrix);

int[,] matrixTranspositioned = MatrixTransposition(matrix);
Console.WriteLine("\nTransponált tömb: ");
WriteMatrixTranspositioned(matrixTranspositioned);

int[,] GetMatrix()
{
    int[,] matrix = new int[squareSizeHeight, squareSizeWidth];
    int temp = 0;

    for (int i = 0; i < squareSizeHeight; i++)
    {
        for (int j = 0; j < squareSizeWidth; j++)
        {
            temp = random.Next(500);
            matrix[i, j] = temp;
        }
    }

    return matrix;
}

void WriteMatrix(int[,] matrix)
{
    for (int i = 0; i < squareSizeHeight; i++)
    {
        for (int j = 0; j < squareSizeWidth; j++)
        {
            Console.Write($"{matrix[i, j]}\t");
        }
        Console.WriteLine();
    }
}

int[,] MatrixTransposition(int[,] matrix)
{
    int[,] result = new int[squareSizeWidth, squareSizeHeight];
    for (int i = 0;i < squareSizeWidth; i++)
    {
        for(int j = 0;j <squareSizeHeight ; j++)
        {
            
            result[i, j] = matrix[j,i];
        }
    }
    return result;
}

void WriteMatrixTranspositioned(int[,] matrix)
{
    for (int i = 0; i < squareSizeWidth; i++)
    {
        for (int j = 0; j < squareSizeHeight; j++)
        {
            Console.Write($"{matrix[i, j]}\t");
        }
        Console.WriteLine();
    }
}