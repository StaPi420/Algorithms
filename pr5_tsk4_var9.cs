using System;

class Program
{

    static void getPrimeFactor(int k, int n)
    {
        if (n != 1)
        {
            while (n % k != 0)
            {
                ++k;
            }
            Console.WriteLine(k);
            getPrimeFactor(k, n / k);
        }
    }
    static void getPrimeFactorForRange(int a, int b)
    {
        for (int i = a; i <= b; ++i)
        {
            Console.WriteLine($"Простые множители для числа {i}:");
            getPrimeFactor(2, i);
        }
    }
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        getPrimeFactorForRange(a, b);
    }
}
