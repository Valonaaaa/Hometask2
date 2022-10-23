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
         UpdateMatrix(matrix);
         PrintMatrix(matrix);
      
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
    public static void UpdateMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i > j)
                {
                    matrix[i, j] = 0;
                }
                else if (i < j)
                {
                    matrix[i, j] = 1;
                 }
            }
        }
    }
}