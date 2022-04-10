using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class SpeedRacing
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                double fuel = double.Parse(tokens[1]);
                double consumption = double.Parse(tokens[2]);

                cars.Add(new Car(name, fuel, consumption));
            }

            string command = Console.ReadLine();

            while (command?.ToUpper() != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[1];
                double distance = double.Parse(tokens[2]);

                foreach (var car in cars)
                {
                    if (car.Model == name)
                    {
                        car.MoveChecker(distance);
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
