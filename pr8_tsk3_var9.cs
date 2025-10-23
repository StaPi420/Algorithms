using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        String file = "C:\\Users\\contest\\source\\repos\\ConsoleApp1\\ConsoleApp1\\cap.txt";

        String str = File.ReadAllText(file);

        Console.Write("Введите слово: ");
        String substr = Console.ReadLine().ToLower();

        char[] separator = { ' ', '.', ',', '!', '?', ';', ':', '\n', '\t', '\r' };

        String[] words = str.Split(separator);

        int res = 0;

        foreach(String word in words)
        {
            if (substr.Equals(word.ToLower()))
            {
                ++res;
            }
        }

        Console.WriteLine(res);
    }

}
