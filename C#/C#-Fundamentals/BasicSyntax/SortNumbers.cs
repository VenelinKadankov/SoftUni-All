using System;

namespace Extra_Exercise
{
    class SortNumbers
    {
        static void Main(string[] args)
        {

            int[] numbersArray = new int[3];

            for(int i = 0; i < 3; i++)
            {

                numbersArray[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(numbersArray, (x, y) => y - x);

            foreach(int num in numbersArray)
            {
                Console.WriteLine(num);
            }
            
        }
    }
}
