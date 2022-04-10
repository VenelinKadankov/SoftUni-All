using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class VehicleCatalogue
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List < Vehicle > catalogue = new List<Vehicle>();


            while (command.ToLower() != "end")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Vehicle current = new Vehicle(tokens[0], tokens[1], tokens[2], int.Parse(tokens[3]));
                catalogue.Add(current);

                command = Console.ReadLine();
            }

            List<Vehicle> cars = catalogue.Where(a => a.Type == "car").ToList();
            List<Vehicle> trucks = catalogue.Where(a => a.Type == "truck").ToList();
            double averageCars = 0, totalPowerCars = 0;
            double averageTrucks = 0, totalPowerTrucks = 0;

            foreach (var item in cars)
            {
                totalPowerCars += item.HorsePower;
            }

            foreach (var item in trucks)
            {
                totalPowerTrucks += item.HorsePower;
            }

            if(cars.Count != 0)
            {
                averageCars = totalPowerCars / cars.Count;
            }

            if (trucks.Count != 0)
            {
                averageTrucks = totalPowerTrucks / trucks.Count;
            }

            command = Console.ReadLine();

            while (command.ToLower() != "close the catalogue")
            {

                for (int i = 0; i < catalogue.Count; i++)
                {

                    if (command == catalogue[i].Model)
                    {
                        if(catalogue[i].Type == "car")
                        {
                            catalogue[i].Type = "Car";
                        }
                        if (catalogue[i].Type == "truck")
                        {
                            catalogue[i].Type = "Truck";
                        }

                        Console.WriteLine($"Type: {catalogue[i].Type}");
                        Console.WriteLine($"Model: {catalogue[i].Model}");
                        Console.WriteLine($"Color: {catalogue[i].Color}");
                        Console.WriteLine($"Horsepower: {catalogue[i].HorsePower}");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Cars have average horsepower of: {averageCars:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageTrucks:F2}.");
        }
    }

    class Vehicle
    {

        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }
}
