using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("C:\\Users\\contest\\fileIn1.txt"))
        {
            char[] sep = { ' ', ',', '.', '\n', '\t', '\r' };
            int[] ar = Array.ConvertAll(reader.ReadToEnd().Split(sep, StringSplitOptions.RemoveEmptyEntries), x => int.Parse(x));
            int n = ar.Length;
            var ansArray = ar.Where(x => Math.Abs(x) > 9 && Math.Abs(x) < 100).Select(x => x + 5);

            foreach (int number in ansArray)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
