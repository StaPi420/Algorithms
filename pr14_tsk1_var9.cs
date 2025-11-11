using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("C:\\Users\\kuram\\.vscode\\csproj\\fileIn.txt"))
        {
            int n = int.Parse(reader.ReadLine());
            SPoint[] pointAr = new SPoint[n];
            for (int i = 0; i < n; ++i)
            {
                string[] line = reader.ReadLine().Split(' ');
                //pointAr[i] = new SPoint();
                pointAr[i].x = int.Parse(line[0]);
                pointAr[i].y = int.Parse(line[1]);
                pointAr[i].z = int.Parse(line[2]);
            }
            int r = int.Parse(Console.ReadLine());
            int ansIndx = 0, maxAmount = 0;
            for (int i = 0; i < n; ++i)
            {
                int curAmount = 0;
                for (int j = 0; j < n; ++j)
                {
                    if (pointAr[i].getDistance(pointAr[j]) <= r)
                    {
                        ++curAmount;
                    }
                }
                Console.WriteLine(curAmount);
                if (curAmount > maxAmount)
                {
                    maxAmount = curAmount;
                    ansIndx = i;
                }
            }
            Console.WriteLine($"{pointAr[ansIndx].x} {pointAr[ansIndx].y} {pointAr[ansIndx].z}");
        }
    }
}

struct SPoint
{
    public int x, y, z;
    public SPoint(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public int getDistance(SPoint other)
    {
        int xOrt = Math.Abs(this.x * this.x - other.x * other.x);
        int yOrt = Math.Abs(this.y * this.y - other.y * other.y);
        int zOrt = Math.Abs(this.z * this.z - other.z * other.z);
        return Math.Abs(xOrt + yOrt + zOrt);
    }
}
