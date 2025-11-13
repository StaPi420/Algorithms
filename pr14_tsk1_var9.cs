using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("C:\\Users\\contest\\fileIn3.txt"))
        {
            int n = int.Parse(reader.ReadLine());
            SPoint[] pointAr = new SPoint[n];
            int[] amount = new int[n];
            for (int i = 0; i < n; ++i)
            {
                string[] line = reader.ReadLine().Split(' ');
                //pointAr[i] = new SPoint();
                pointAr[i].x = int.Parse(line[0]);
                pointAr[i].y = int.Parse(line[1]);
            }
            int r = int.Parse(Console.ReadLine());
            int maxAmount = 0;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (pointAr[i].getDistance(pointAr[j]) <= r)
                    {
                        ++amount[i];
                    }
                }
                Console.WriteLine(amount[i]);
                maxAmount = Math.Max(maxAmount, amount[i]);
            }
            using (StreamWriter writer = new StreamWriter("C:\\Users\\contest\\fileOut.txt"))
            {
                for (int i = 0; i < n; ++i)
                {
                    if (amount[i] == maxAmount)
                    {
                        writer.WriteLine($"{pointAr[i].x} {pointAr[i].y}");
                    }
                }
            }
        }
    }
}

struct SPoint
{
    public int x, y;
    public int getDistance(SPoint other)
    {
        int xOrt = Math.Abs(this.x * this.x - other.x * other.x);
        int yOrt = Math.Abs(this.y * this.y - other.y * other.y);
        return Math.Abs(xOrt + yOrt);
    }
}
