using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Weight = "n/a";
            Color = "n/a";
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

        private string weight;

        public string Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string ToString(string model, Engine engine)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"  {this.Engine.ToString(Engine.Model)}");
            sb.AppendLine($"  Weight: {this.Weight}");
            sb.Append($"  Color: {this.Color}");

            return sb.ToString();
        }
    }
}
