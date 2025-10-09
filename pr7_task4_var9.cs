using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] array = new int[n, n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    array[i, j] = int.Parse(Console.ReadLine());

                }
            }
            int a = int.Parse(Console.ReadLine());
            int[] ans = new int[n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (array[i, j] > a)
                        ++ans[i];
                }
            }
            foreach(int elem in ans)
                Console.Write($"{elem} ");
        }
    }
}
