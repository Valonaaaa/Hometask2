using System.Drawing;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        char[,] previous = new char[5, 9]
        {
            { '+', '-', '+', '-', '-', '-', '-', '-', '+' },
            { '+', '-', '+', '-', '-', '+', '-', '-', '+' },
            { '-', '-', '+', '-', '-', '-', '-', '-', '+' },
            { '+', '-', '+', '-', '-', '+', '-', '-', '+' },
            { '-', '-', '+', '-', '-', '+', '-', '-', '+' },
        };

        PrintState(previous);

        bool run = true;
        while (run)
        {
            Console.ReadKey();

            var current = GetNewGeneration(previous);

            PrintState(current);

            if (Compare(current, previous) || IsEmpty(current))
            {
                Console.WriteLine("Game over!");
                run = false;
            }

            previous = current;
        }
    }


    private static bool Compare(char[,] a, char[,] b)
    {
        int rowsCount = a.GetLength(0);
        int rowLength = a.GetLength(1);

        for (int i = 0; i < rowsCount; i++)
        {
            for (int j = 0; j < rowLength; j++)
            {
                if (a[i, j] != b[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static bool IsEmpty(char[,] a)
    {
        int rowsCount = a.GetLength(0);
        int rowLength = a.GetLength(1);

        for (int i = 0; i < rowsCount; i++)
        {
            for (int j = 0; j < rowLength; j++)
            {
                if (a[i, j] == '+')
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static void PrintState(char[,] matrix)
    {
        int rowsCount = matrix.GetLength(0);
        int rowLength = matrix.GetLength(1);
        for (int i = 0; i < rowsCount; i++)
        {
            Console.Write($"{rowsCount - i} ");
            for (int j = 0; j < rowLength; j++)
            {
                Console.Write($"{matrix[i, j]} ");

            }
            Console.WriteLine();
        }
        Console.Write($"{0} ");
        for (int i = 0; i < rowLength; i++)
        {
            Console.Write($"{i + 1} ");
        }
        Console.WriteLine();
        Console.WriteLine();
    }
    private static char[,] GetNewGeneration(char[,] matrix)
    {
        int rowsCount = matrix.GetLength(0);
        int rowLength = matrix.GetLength(1);

        char[,] result = new char[rowsCount, rowLength];

        for (int i = 0; i < rowsCount; i++)
        {
            for (int j = 0; j < rowLength; j++)
            {
                int aliveCount = GetAliveCount(matrix, i, j);
                if (aliveCount <= 1 || aliveCount >= 3)
                {
                    result[i, j] = '-';
                }
                else if (aliveCount == 2)
                {
                    result[i, j] = '+';
                }
                else
                {
                    result[i, j] = matrix[i, j];
                }
            }
        }

        return result;
    }

    private static int GetAliveCount(char[,] matrix, int i, int j)
    {
        int rowsCount = matrix.GetLength(0);
        int rowLength = matrix.GetLength(1);

        bool up = i > 0;
        bool down = i < rowsCount - 1;
        bool left = j > 0;
        bool right = j < rowLength - 1;

        int aliveCount = 0;

        if (up)
        {
            if (left && matrix[i - 1, j - 1] == '+')
            {
                aliveCount += 1;
            }

            if (right && matrix[i - 1, j + 1] == '+')
            {
                aliveCount += 1;
            }

            if (matrix[i - 1, j] == '+')
            {
                aliveCount += 1;
            }
        }

        if (down)
        {
            if (left && matrix[i + 1, j - 1] == '+')
            {
                aliveCount += 1;
            }

            if (right && matrix[i + 1, j + 1] == '+')
            {
                aliveCount += 1;
            }

            if (matrix[i + 1, j] == '+')
            {
                aliveCount += 1;
            }
        }

        if (left && matrix[i, j - 1] == '+')
        {
            aliveCount += 1;
        }

        if (right && matrix[i, j + 1] == '+')
        {
            aliveCount += 1;
        }

        return aliveCount;
    }
}