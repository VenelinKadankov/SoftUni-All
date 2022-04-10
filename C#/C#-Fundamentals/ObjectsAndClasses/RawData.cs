using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class RawData
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = CreateCarList(n);
            string searchedType = Console.ReadLine();
            PrintWanted(cars, searchedType);
        }

        static List<Car> CreateCarList(int n)
        {
            List<Car> cars = new List<Car>(n);

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = tokens[0], cargoType = tokens[4];
                int speed = int.Parse(tokens[1]), power = int.Parse(tokens[2]), weight = int.Parse(tokens[3]);
                Car currentCar = new Car(model, speed, power, weight, cargoType);
                cars.Add(currentCar);
            }

            return cars;
        }

        static void PrintWanted(List<Car> cars, string type)
        {

            if (type == "fragile")
            {
                List<Car> wanted = cars.Where(a => a.Cargo.Type == type && a.Cargo.Weight < 1000).ToList();
                wanted.ForEach(a => Console.WriteLine(a.Model));
            }
            else
            {
                List<Car> wanted = cars.Where(a => a.Cargo.Type == type && a.Engine.Power > 250).ToList();
                wanted.ForEach(a => Console.WriteLine(a.Model));
            }
        }
    }


    class Car
    {
        public Car(string model, int speed, int power, int weight, string type)
        {
            Model = model;
            Engine = new Engine(speed, power);
            Cargo = new Cargo(weight, type);
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }

    }

    class Engine
    {
        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
        public int Speed { get; set; }

        public int Power { get; set; }


    }

    class Cargo
    {
        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
        public int Weight { get; set; }
        public string Type { get; set; }
    }
}
