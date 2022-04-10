using System;
using System.IO;

namespace LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            //using (StreamWriter writer = new StreamWriter("../../../input.txt"))
            //{
            //    string line = Console.ReadLine();

            //    while (line != "")
            //    {
            //        writer.WriteLine(line);
            //        line = Console.ReadLine();
            //    }
            //}

            using (StreamReader reader = new StreamReader("../../../input.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    string line = reader.ReadLine();
                    int counter = 1;
                    while (line != null)
                    {
                        writer.WriteLine($"{counter}. {line}");
                        counter++;
                        line = reader.ReadLine();
                    }
                }

            }

        }
    }
}
