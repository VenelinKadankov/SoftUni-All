using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
         
        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }


        public int Count => this.cars.Count;



        public string AddCar(Car car)
        {

            if (this.cars.Any(a => a.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            
            if (this.cars.Count == this.capacity)
            {
                return "Parking is full!";
            }

            this.cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";

        }

        public string RemoveCar(string regNum)
        {

            if (this.cars.All(a => a.RegistrationNumber != regNum))
            {
                return "Car with that registration number, doesn't exist!";
            }

            this.cars = this.cars.Where(a => a.RegistrationNumber != regNum).ToList();

            return $"Successfully removed {regNum}";

        }

        public Car GetCar(string regNum)
        {
            Car wanted = this.cars.FirstOrDefault(a => a.RegistrationNumber == regNum);
            return wanted;
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {   
            foreach (string number in RegistrationNumbers)
            {
                Car current = this.cars.FirstOrDefault(a => a.RegistrationNumber == number);

                if (current != null)
                {
                    this.cars.Remove(current);
                }
            }
        }
    }
}
