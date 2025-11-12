using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("C:\\Users\\kuram\\.vscode\\csproj\\fileIn.txt"))
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
            
            foreach (int number  in ansArray)
            {
                Console.Write($"{number} ");
            }
        }
    }
}

