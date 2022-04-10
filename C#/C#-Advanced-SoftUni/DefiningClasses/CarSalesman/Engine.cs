using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public Engine(string model)
        {
            Model = model;
            Power = 0;
            Displacement = "n/a";
            Efficiency = "n/a";
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private int power;

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        private string displacement;

        public string Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }

        private string efficiency;

        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }

        public string ToString(string model)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"    Power: {this.Power.ToString()}");
            sb.AppendLine($"    Displacement: {this.Displacement}");
            sb.Append($"    Efficiency: {this.Efficiency}");

            return sb.ToString();
        }
    }
}
