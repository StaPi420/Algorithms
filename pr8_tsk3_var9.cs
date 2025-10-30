using System;
using System.IO;

class Program
{
    static void Main()
    {
        String file = "C:\\Users\\contest\\source\\repos\\ConsoleApp1\\cap.txt.txt";

        StreamReader reader = new StreamReader(file);

        Console.Write("Введите слово: ");
        String substr = Console.ReadLine().ToLower();

        char[] separator = { ' ', '.', ',', '!', '?', ';', ':', '\n', '\t', '\r' };

        String[] words = reader.ReadToEnd().Split(separator);

        int res = 0;

        foreach (String word in words)
        {
            if (substr.Equals(word.ToLower()))
            {
                ++res;
            }
        }

        Console.WriteLine(res);
    }

}
