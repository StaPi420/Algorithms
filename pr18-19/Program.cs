using System;
using System.Collections;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Text.Json;
using ConsoleApp2;

class Program
{
    private static Random random = new Random();
    private static string filePath = "data.json";

    public static Vehicle[] GetAll()
    {
        if (!File.Exists(filePath))
            return new Vehicle[100];

        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<Vehicle[]>(json) ?? new();
    }
    public static void GenerateFile()
    {
        Vehicle[] vehicles = new Vehicle[100];
        for (int i = 0; i < 34; ++i)
        {
            vehicles[i] = new Car(GetRandomBrand(), GetRandomNumber(), random.Next(100, 200), random.Next(0, 2000));
        }
        for (int i = 34; i < 67; ++i)
        {
            vehicles[i] = new Motorcycle(GetRandomBrand(), GetRandomNumber(), random.Next(100, 200), random.Next(0, 1000), random.Next(2) == 0);
        }
        for (int i = 67; i < 100; ++i)
        {
            vehicles[i] = new Truck(GetRandomBrand(), GetRandomNumber(), random.Next(70, 150), random.Next(0, 10000), random.Next(2) == 0);
        }
        Save(vehicles);
    }

    public static void Save(Vehicle[] faculties)
    {
        var json = JsonSerializer.Serialize(faculties, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(filePath, json);
    }
    public static string GetRandomNumber()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    public static string GetRandomBrand()
    {
        string[] brands = new string[] { "BMW", "LADA", "FORD", "MERSEDEZ" };
        return brands[random.Next(4)];
    }
    public static void Main()
    {
        GenerateFile();
        var vehicles = GetAll();
        Console.Write("Введите минимальную необходимую грузоподьёмность:");
        int minLiftingCapacity = int.Parse(Console.ReadLine());
        var satysfyingVehicles = vehicles
        .Where(s => s.LiftingCapacity >= minLiftingCapacity)
        .OrderByDescending(s => s);

        foreach (Vehicle vehicle in satysfyingVehicles)
        {
            vehicle.Show();
        }
    }
}
