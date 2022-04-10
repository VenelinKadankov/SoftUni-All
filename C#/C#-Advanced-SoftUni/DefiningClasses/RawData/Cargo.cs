namespace RawData
{
    public class Cargo
    {
        public Cargo(int weight, string type)
        {
            CargoWeight = weight;
            CargoType = type;
        }

        private int cargoWeight;

        public int CargoWeight
        {
            get { return cargoWeight; }
            set { cargoWeight = value; }
        }

        private string cargoType;

        public string CargoType
        {
            get { return cargoType; }
            set { cargoType = value; }
        }

    }
}
