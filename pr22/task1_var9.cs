using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        var lines = File.ReadAllLines("input.txt");

        int n = int.Parse(lines[0]);

        int[,] matrix = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            var row = lines[i + 1]
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int j = 0; j < n; j++)
                matrix[i, j] = row[j];
        }

        int v = int.Parse(lines[n + 1]) - 1; // к 0-based

        bool found = false;

        for (int i = 0; i < n; i++)
        {
            if (matrix[i, v] == 1)
            {
                Console.WriteLine(i + 1); // обратно к 1-based
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("NO");
    }
}
