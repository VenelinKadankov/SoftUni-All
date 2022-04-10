using System;

namespace ExtractPersonInformation
{
    class ExtractInfo
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                int indexOfAt = line.IndexOf('@');
                int indexOfLine = line.IndexOf('|');
                int indexOfDies = line.IndexOf('#');
                int indexOfStar = line.IndexOf('*');

                int lengthName = indexOfLine - indexOfAt - 1;
                int lengthAge = indexOfStar - indexOfDies - 1;

                string name = line.Substring(indexOfAt + 1, lengthName);
                string years = line.Substring(indexOfDies + 1, lengthAge);
                int age = int.Parse(years);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
