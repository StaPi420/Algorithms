using System;

class Program
{

    static double F(int n)
    {
        return n / getDenominator(1, n);
    }
    static double getDenominator(int k, int n)
    {
        if (k == n) return Math.Sqrt(n);
        else return Math.Sqrt(k + getDenominator(k + 1, n));
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(F(n));
    }
}
