using System;

class Program
{
    static int BinPow(int x, int n)
    {
        int res = 1;
        while (n > 0)
        {
            if (n % 2 == 1)
            {
                res *= x;
            }
            n >>= 1;
            x *= x;
        }
        return res;
    }


    static void Main()
    {
        // Пункт a
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());

        Console.WriteLine("Пункт a");

        int n = 1;
        int bRes = 0;
        for (int i = a; i <= b; i += h)
        {
            int binPowRes = BinPow(i, n);
            Console.WriteLine(binPowRes);
            n += 1;
            bRes += binPowRes;
        }

        // Пункт b
        Console.WriteLine("Пункт b");
        Console.WriteLine(bRes);

        //Пункт c
        Console.WriteLine("Пункт c");
        for (int i = a; i < b; ++i)
        {
            for (int j = i + 1; j <= b; ++j)
            {
                for (int hypotenuse = j + 1; hypotenuse <= b; ++hypotenuse)
                {
                    if (i * i + j * j == hypotenuse * hypotenuse)
                    {
                        Console.WriteLine($"{i}, {j}, {hypotenuse}");
                    }
                }
            }
        }

        // Пункт d
        Console.WriteLine("Пункт d");
        a = int.Parse(Console.ReadLine());

        for (int i = 1; i < 33; ++i)
        {
            if (2 << (i - 1) <= a && a < 2 << i)
            {
                Console.WriteLine(i);
            }
        }
    }
}