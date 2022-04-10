using System;
using System.IO;

namespace OddLines
{
    class OddLines
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
                    int counter = 0;

                    while (line != "")
                    {


                        if (counter % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }

                        counter++;

                        line = reader.ReadLine();
                    }
                }

            }
        }
    }
}
