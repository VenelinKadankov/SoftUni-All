namespace RawData
{
    public class Car
    {
        public Car(string model, int speed, int power,int weight,string type,double tire1Pressure,int tire1Age,
            double tire2Pressure,int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
        {
            Model = model;
            Engine = new Engine(speed, power);
            Cargo = new Cargo(weight, type);
            Tires = new Tire[4];
            Tires[0] = new Tire(tire1Pressure, tire1Age);
            Tires[1] = new Tire(tire2Pressure, tire2Age);
            Tires[2] = new Tire(tire3Pressure, tire3Age);
            Tires[3] = new Tire(tire4Pressure, tire4Age);
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private Engine engine;

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        private Cargo cargo;

        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        private Tire[] tires;

        public Tire[] Tires
        {
            get { return tires; }
            set { tires = value; }
        }


    }
}
