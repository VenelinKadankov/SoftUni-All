using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuel, double consumption)
        {
            Model = model;
            FuelAmount = fuel;
            FuelConsumptionPerKilometer = consumption;
            TravelledDistance = 0;
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private double fuelAmount;

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        private double fuelConsumptionPerKilometer;

        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }

        private double travelledDistance;

        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }

        public void MoveChecker(double amountKM)
        {
            if(amountKM * this.FuelConsumptionPerKilometer <= this.FuelAmount)
            {
                FuelAmount -= amountKM * FuelConsumptionPerKilometer;
                TravelledDistance += amountKM;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
