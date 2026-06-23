using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleApp2;

class Program
{
    private static readonly Random random = new Random();
    private static readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "vehicles.json");

    public static string GetRandomNumber()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public static string GetRandomBrand()
    {
        string[] brands = { "BMW", "LADA", "FORD", "MERCEDES" };
        return brands[random.Next(brands.Length)];
    }

    public static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out int value) && value >= 0)
            {
                return value;
            }

            Console.WriteLine("Введите целое неотрицательное число.");
        }
    }

    public static List<Vehicle> GenerateVehicles(int carCount, int motorcycleCount, int truckCount)
    {
        var vehicles = new List<Vehicle>();

        for (int i = 0; i < carCount; i++)
        {
            vehicles.Add(new Car(GetRandomBrand(), GetRandomNumber(), random.Next(80, 181), random.Next(500, 4001)));
        }

        for (int i = 0; i < motorcycleCount; i++)
        {
            vehicles.Add(new Motorcycle(GetRandomBrand(), GetRandomNumber(), random.Next(60, 151), random.Next(100, 1001), random.Next(0, 2) == 1));
        }

        for (int i = 0; i < truckCount; i++)
        {
            vehicles.Add(new Truck(GetRandomBrand(), GetRandomNumber(), random.Next(50, 121), random.Next(1000, 8001), random.Next(0, 2) == 1));
        }

        return vehicles;
    }

    public static void SaveVehicles(string path, IEnumerable<Vehicle> vehicles)
    {
        JsonHelper.SaveToFile(vehicles.ToList(), path);
    }

    public static List<Vehicle> LoadVehicles(string path)
    {
        if (!File.Exists(path) || new FileInfo(path).Length == 0)
        {
            return null;
        }

        try
        {
            return JsonHelper.LoadFromFile<List<Vehicle>>(path);
        }
        catch
        {
            return null;
        }
    }

    public static void Main()
    {
        List<Vehicle> vehicles = LoadVehicles(filePath);

        if (vehicles == null)
        {
            Console.WriteLine("Файл не найден или пуст. Генерируем новые элементы.");
            int carCount = ReadInt("Сколько автомобилей сгенерировать? ");
            int motorcycleCount = ReadInt("Сколько мотоциклов сгенерировать? ");
            int truckCount = ReadInt("Сколько грузовиков сгенерировать? ");

            vehicles = GenerateVehicles(carCount, motorcycleCount, truckCount);
            SaveVehicles(filePath, vehicles);
        }
        int minWeight = ReadInt("Введите минимальный вес: ");

        var filtered = vehicles
            .Where(v => v.LiftingCapacity >= minWeight)
            .OrderBy(v => v.LiftingCapacity)
            .ToList();

        Console.WriteLine("\nОтсортированный список:");
        foreach (var vehicle in filtered)
        {
            Console.WriteLine(vehicle + "\n");
        }
    }
}
