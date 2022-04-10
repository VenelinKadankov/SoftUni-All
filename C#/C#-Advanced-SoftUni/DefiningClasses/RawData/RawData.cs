using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                cars.Add(new Car(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2]), int.Parse(tokens[3]), tokens[4],
                    double.Parse(tokens[5]), int.Parse(tokens[6]), double.Parse(tokens[7]), int.Parse(tokens[8]),
                    double.Parse(tokens[9]), int.Parse(tokens[10]), double.Parse(tokens[11]), int.Parse(tokens[12])));
            }

            string type = Console.ReadLine();

            foreach (var car in cars)
            {
                if (type == "fragile" && car.Tires.Any(a => a.TirePressure < 1))
                {
                    Console.WriteLine(car.Model);
                }
                else if (type == "flamable" && car.Engine.EnginePower > 250)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
