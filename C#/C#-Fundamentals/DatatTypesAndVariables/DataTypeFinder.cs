using System;

namespace DataTypeFinder
{
    class DataTypeFinder
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();

            while (line != "END")
            {
                int i = 0;
                float j = 0.0F;
                bool isBool = false;
                char character = 'a';
                string name = "string";
                if (int.TryParse(line, out i))
                {
                    name = "integer";
                }
                else if (float.TryParse(line, out j))
                {
                    name = "floating point";
                }
                else if (bool.TryParse(line, out isBool))
                {
                    name = "boolean";
                }
                else if (char.TryParse(line, out character))
                {
                    name = "character";
                }

                Console.WriteLine($"{line} is {name} type");

                line = Console.ReadLine();
            }
        }
    }
}
