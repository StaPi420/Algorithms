using System;
using System.Text;
using System.IO;

class Program
{
    static void Main()
    {
        string fileInPath1 = "C:\\Users\\kuram\\.vscode\\csproj\\fileIn1.txt";
        string fileInPath2 = "C:\\Users\\kuram\\.vscode\\csproj\\fileIn2.txt";
        string fileOutPath = "C:\\Users\\kuram\\.vscode\\csproj\\fileOut.txt";

        string[] fileIn1 = File.ReadAllLines(fileInPath1);
        string[] fileIn2 = File.ReadAllLines(fileInPath2);

        File.Create(fileOutPath).Close();
        

        for (int i = 0; i < Math.Min(fileIn1.Length, fileIn2.Length); ++i)
        {
            File.AppendAllText(fileOutPath, fileIn1[i] + '\n');
            File.AppendAllText(fileOutPath, fileIn2[i] + '\n');
        }
    }
}
