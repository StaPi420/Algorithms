using System;
using System.IO;

class Program
{
    static void Main()
    {
        string fileInPath1 = "C:\\Users\\contest\\Desktop\\fileIn1.txt";
        string fileInPath2 = "C:\\Users\\contest\\Desktop\\fileIn2.txt";
        string fileOutPath = "C:\\Users\\contest\\Desktop\\fileOut.txt";

        StreamReader reader1 = new StreamReader(fileInPath1);
        StreamReader reader2 = new StreamReader(fileInPath2);

        char[] separator = { ' ', '.', ',', '!', '?', ';', ':', '\n', '\t', '\r', '\v' };

        string[] fileIn1 = reader1.ReadToEnd().Split(separator);
        string[] fileIn2 = reader2.ReadToEnd().Split(separator);

        File.Create(fileOutPath).Close();

        foreach (string s in fileIn1)
        {
            Console.Write(s.Trim() + ' ');
        }
        foreach (string s in fileIn2)
        {
            Console.Write(s.Trim() + ' ');
        }

        for (int i = 0; i < Math.Min(fileIn1.Length, fileIn2.Length); ++i)
        {
            if (!fileIn1[i].Equals("") || !fileIn2[i].Equals(""))
            {
                File.AppendAllText(fileOutPath, fileIn1[i].Trim() + '\n');
                File.AppendAllText(fileOutPath, fileIn2[i].Trim() + '\n');
            }
        }
    }
}
