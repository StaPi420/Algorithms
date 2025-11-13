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
            string[] ar = new string[n];
            for (int i = 0; i < n; ++i)
            {
                ar[i] = reader.ReadLine();
            }
            var ansArray = from number in ar 
                           where number.Length == 2
                           select int.Parse(number) + 5;

            foreach (int number in ansArray)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
