using System;
using System.Collections.Generic;

namespace CarSalesman
{
    class CarSalesman
    {
        static void Main(string[] args)
        {
            int countEngines = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < countEngines; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine current = new Engine(data[0])
                {
                    Power = int.Parse(data[1])
                };

                if (data.Length == 4)
                {
                    current.Displacement = data[2];
                    current.Efficiency = data[3];
                }
                else if (data.Length == 3)
                {
                    if (int.TryParse(data[2], out int num))
                    {
                        current.Displacement = data[2];
                    }
                    else
                    {
                        current.Efficiency = data[2];
                    }

                }

                engines.Add(current);
            }

            int countCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < countCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = carInfo[0];
                string engine = carInfo[1];
                Car currentCar = new Car(name, new Engine(engine));

                foreach (var engineType in engines)
                {
                    if (engine == engineType.Model)
                    {
                        currentCar.Engine = engineType;

                        if (carInfo.Length == 3)
                        {
                            if (int.TryParse(carInfo[2], out int num))
                            {
                                currentCar.Weight = carInfo[2];
                            }
                            else
                            {
                                currentCar.Color = carInfo[2];
                            }
                        }
                        else if (carInfo.Length == 4)
                        {
                            currentCar.Weight = carInfo[2];
                            currentCar.Color = carInfo[3];
                        }

                    }
                }
                cars.Add(currentCar);
            }

            foreach (var car in cars)
            {
                var name = car.Engine.Model;
                Console.WriteLine(car.ToString(car.Model, car.Engine));
            }

        }
    }
}
