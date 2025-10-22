using System;
class Program
{   
    static void Main()
    {
        Console.Write("Введите строку: ");
        String str = Console.ReadLine();

        Console.Write("Введите подстроку: ");
        String substr = Console.ReadLine();

        int res = str.Split(substr).Length - 1;

        Console.WriteLine(res);
    }
}