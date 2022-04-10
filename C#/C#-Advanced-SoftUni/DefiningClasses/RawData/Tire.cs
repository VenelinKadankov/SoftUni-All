namespace RawData
{
    public class Tire
    {
        public Tire(double presure, int age)
        {
            TirePressure = presure;
            TireAge = age;
        }

        private double tirePressure;

        public double TirePressure
        {
            get { return tirePressure; }
            set { tirePressure = value; }
        }

        private int tireAge;

        public int TireAge
        {
            get { return tireAge; }
            set { tireAge = value; }
        }

    }
}
