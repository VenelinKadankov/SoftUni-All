using System;

namespace Triangle_of_numbers
{
    class triangle
    {
        static void Main(string[] args)
        {
            int givenNum = int.Parse(Console.ReadLine());

            for (int i = 1; i <= givenNum; i++)
            {
                string line = $"{i}";
                
                for (int j = 1; j < i; j++)
                {
                    line = line + " " + i;
                }

                Console.WriteLine(line);
            }

        }
    }
}
