using System;
using System.Numerics;

class Program
{   
    static void moveColumns(int[][] matrix, int column, int cntColumns)
    {
        for (int i = 0; i < cntColumns - 1; ++i)
        {
            matrix[i] = matrix[i + 1];
        }
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        for (int i = 0; i < n; ++i)
        {
            string[] col = Console.ReadLine().Split(' ');

            for (int j = 0; j < n; ++j)
            {
                matrix[i, j] = int.Parse(col[j]);
            }
        }

        int[][] stair_matrix = new int[n][];
        for (int i = 0; i < n; ++i)
        {
            stair_matrix[i] = new int[n];
            for (int j = 0; j < n; ++j)
            {
                stair_matrix[i][j] = matrix[j, i];
            }
        }

        int cntColumns = n;

        for (int i = 0; i < n;)
        {
            int cntOdd = 0;
            for (int j = 0; j < n; ++j)
            {
                if (stair_matrix[i][j] % 2 == 1)
                    ++cntOdd;
            }
            if (cntOdd % 2 == 0)
            {
                moveColumns(stair_matrix, i, cntColumns--);
            }
            else
            {
                ++i;
            }
        }


        if (cntColumns > 0)
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < cntColumns; ++j)
                {
                    Console.Write($"{stair_matrix[j][i]} ");
                }
                Console.WriteLine();
            }
    }

}
