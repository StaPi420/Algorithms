using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("C:\\Users\\contest\\fileIn1.txt"))
        {
            int n = int.Parse(reader.ReadLine());
            int[] ar = new int[n];
            for (int i = 0; i < n; ++i)
            {
                ar[i] = int.Parse(reader.ReadLine());
            }
            var ansArray = from number in ar
                           where Math.Abs(number) > 9 && Math.Abs(number) < 100 
                           select number + 5;

            foreach (int number in ansArray)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
