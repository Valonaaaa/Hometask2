using System.Reflection.Metadata.Ecma335;

internal class Program
{
    private static void Main(string[] args)
    {
        int[,] matrix = new int[3, 3] {
           { 0, 1, 2 },
           { 3, 4, 5 },
           { 6, 7, 8 }
        };
        PrintMatrix(matrix);
        int[,] result = UpdateMatrix(matrix);
        PrintMatrix(result);
        

    }
    public static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.WriteLine($"{matrix[i, j]} ({i};{j})");
            }
        }

    }
    public static int[,] UpdateMatrix(int[,] matrix)
    {
        int rowsCount = matrix.GetLength(0);
        int rowsLength = matrix.GetLength(1);

        int[,] result = new int[rowsCount, rowsLength]; 

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i > j)
                {
                    result[i, j] = 0;
                }
                else if (i < j)
                {
                    result[i, j] = 1;
                }
            }
        }
        return result;
    }
}