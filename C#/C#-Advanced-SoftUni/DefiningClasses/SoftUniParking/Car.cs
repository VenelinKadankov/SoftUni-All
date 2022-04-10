using System;

namespace SoftUniParking
{
    public class Car
    {

        public Car(string make, string model, int power, string regNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = power;
            this.RegistrationNumber = regNumber;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }

        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            string result = $"Make: {this.Make}" + Environment.NewLine +
                $"Model: {this.Model}" + Environment.NewLine +
                $"HorsePower: {this.HorsePower}" + Environment.NewLine +
                $"RegistrationNumber: {this.RegistrationNumber}";

            return result;
        }
    }
}
