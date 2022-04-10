using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private IList<Car> data;

        public Parking(string type, int capacity)
        {
            this.data = new List<Car>();
            this.Type = type;
            this.Capacity = capacity;
        }

        public int Count => this.data.Count;
        public string Type { get; set; }

        public int Capacity { get; set; }

        public void Add(Car car)
        {
            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            bool hasCar = false;

            if (data.Any(c => c.Manufacturer.Equals(manufacturer) && c.Model.Equals(model)))
            {
                hasCar = true;

                Car car = data.FirstOrDefault(c => c.Manufacturer.Equals(manufacturer) && c.Model.Equals(model));

                data.Remove(car);
            }

            return hasCar;
        }

        public Car GetLatestCar()
        {
            Car car = data.OrderByDescending(c => c.Year).FirstOrDefault();

            return car;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car car = data.FirstOrDefault(c => c.Manufacturer.Equals(manufacturer) && c.Model.Equals(model));

            return car;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");

            foreach (var car in data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString();
        }
    }
}
