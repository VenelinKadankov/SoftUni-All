using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class SpeedRacing
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> register = CreateRegister(n);
            DriveCars(register);
            PrintResult(register);
        }

        public static List<Car> CreateRegister(int n)
        {
            List<Car> register = new List<Car>(n);

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Car current = new Car(line[0], double.Parse(line[1]), double.Parse(line[2]));
                register.Add(current);
            }

            return register;
        }

        public static List<Car> DriveCars(List<Car> cars)
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] line = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = line[1];
                int distance = int.Parse(line[2]);

                for (int j = 0; j < cars.Count; j++)
                {
                    if (model == cars[j].Model)
                    {
                        cars[j].DriveIfPossible(cars[j], distance);
                    }
                }

                command = Console.ReadLine();
            }

            return cars;
        }

        public static void PrintResult(List<Car> cars)
        {
            cars.ForEach(a => Console.WriteLine($"{a.Model} {a.FuelAmount:F2} {a.traveledDistance}"));
        }
    }

    class Car
    {
        public Car(string model, double fuelAmount, double fuelPerKm)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelPerKm = fuelPerKm;
            traveledDistance = 0;
            
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelPerKm { get; set; }
        public int traveledDistance { get; set; }


        public Car DriveIfPossible(Car car, int distance)
        {
            double fuelNeeded = distance * car.FuelPerKm;

            if (fuelNeeded <= car.FuelAmount)
            {
                car.FuelAmount -= fuelNeeded;
                car.traveledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }

            return car;
        }
    }
}
