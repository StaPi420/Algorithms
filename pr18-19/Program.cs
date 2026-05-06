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

    public static void Save(Vehicle[] vehicles)
    {
        var lines = new List<string>();
    
        foreach (var v in vehicles)
        {
            if (v is Car car)
            {
                lines.Add($"Car;{car.Brand};{car.Number};{car.Speed};{car.LiftingCapacity}");
            }
            else if (v is Motorcycle m)
            {
                lines.Add($"Motorcycle;{m.Brand};{m.Number};{m.Speed};{m.LiftingCapacity};{m.HasSidecar}");
            }
            else if (v is Truck t)
            {
                lines.Add($"Truck;{t.Brand};{t.Number};{t.Speed};{t.LiftingCapacity};{t.HasTrailer}");
            }
        }
    
        File.WriteAllLines(filePath, lines);
    }
    public static Vehicle[] GetAll()
    {
        if (!File.Exists(filePath))
            return Array.Empty<Vehicle>();
    
        var lines = File.ReadAllLines(filePath);
        var vehicles = new List<Vehicle>();
    
        foreach (var line in lines)
        {
            var parts = line.Split(';');
    
            switch (parts[0])
            {
                case "Car":
                    vehicles.Add(new Car(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        int.Parse(parts[4])
                    ));
                    break;
    
                case "Motorcycle":
                    vehicles.Add(new Motorcycle(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        bool.Parse(parts[5])
                    ));
                    break;
    
                case "Truck":
                    vehicles.Add(new Truck(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        bool.Parse(parts[5])
                    ));
                    break;
            }
        }

        return vehicles.ToArray();
    }
    public static void GenerateFile()
    {
        Vehicle[] vehicles = new Vehicle[100];
    
        for (int i = 0; i < 34; ++i)
            vehicles[i] = new Car(GetRandomBrand(), GetRandomNumber(), random.Next(100, 200), random.Next(0, 2000));
    
        for (int i = 34; i < 67; ++i)
            vehicles[i] = new Motorcycle(GetRandomBrand(), GetRandomNumber(), random.Next(100, 200), random.Next(0, 1000), random.Next(2) == 0);
    
        for (int i = 67; i < 100; ++i)
            vehicles[i] = new Truck(GetRandomBrand(), GetRandomNumber(), random.Next(70, 150), random.Next(0, 10000), random.Next(2) == 0);
    
        Save(vehicles);
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
            .OrderByDescending(s => s.LiftingCapacity);

        foreach (Vehicle vehicle in satysfyingVehicles)
        {
            vehicle.Show();
        }
    }
}
