using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeed
{
    class NeedForSpeed
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> cars = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string car = line[0];
                int mileage = int.Parse(line[1]);
                int fuel = int.Parse(line[2]);

                if (!cars.ContainsKey(car))
                {
                    cars.Add(car, new List<int>());
                    cars[car].Add(mileage);
                    cars[car].Add(fuel);
                }
            }

            string command = Console.ReadLine();

            while (command?.ToLower() != "stop")
            {
                string[] tokens = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                string car = tokens[1];

                if (action?.ToLower() == "drive")
                {
                    int dist = int.Parse(tokens[2]);
                    int fuelNeeded = int.Parse(tokens[3]);

                    if (cars.ContainsKey(car))
                    {
                        if (cars[car][1] >= fuelNeeded)
                        {
                            cars[car][0] += dist;
                            cars[car][1] -= fuelNeeded;
                            Console.WriteLine($"{car} driven for {dist} kilometers. {fuelNeeded} liters of fuel consumed.");
                        }
                        else
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }
                    }

                    if (cars[car][0] >= 100000)
                    {
                        Console.WriteLine($"Time to sell the {car}!");
                        cars.Remove(car);
                    }
                }
                else if (action?.ToLower() == "refuel")
                {
                    int fuel = int.Parse(tokens[2]);
                    int refuel = fuel;

                    if (cars[car][1] + fuel > 75)
                    {
                        fuel = 75 - cars[car][1];
                    }

                    cars[car][1] += fuel;
                    Console.WriteLine($"{car} refueled with {fuel} liters");
                }
                else if (action?.ToLower() == "revert")
                {
                    int km = int.Parse(tokens[2]);

                    if (cars[car][0] - km < 10000)
                    {
                        cars[car][0] = 10000;
                    }
                    else
                    {
                        cars[car][0] -= km;
                        Console.WriteLine($"{car} mileage decreased by {km} kilometers");
                    }
                }

                command = Console.ReadLine();
            }

            var result = cars.OrderByDescending(a => a.Value[0])
                .ThenBy(a => a.Key)
                .ToDictionary(a => a.Key, a => a.Value);

            foreach (var car in result)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: {car.Value[1]} lt.");
            }
        }
    }
}
