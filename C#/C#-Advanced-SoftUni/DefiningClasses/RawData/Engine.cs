namespace RawData
{
    public class Engine
    {
        public Engine(int speed, int power)
        {
            EngineSpeed = speed;
            EnginePower = power;
        }
        private int engineSpeed;

        public int EngineSpeed
        {
            get { return engineSpeed; }
            set { engineSpeed = value; }
        }

        private int enginePower;

        public int EnginePower
        {
            get { return enginePower; }
            set { enginePower = value; }
        }


    }
}
