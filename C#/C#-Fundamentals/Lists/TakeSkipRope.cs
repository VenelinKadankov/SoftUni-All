using System;
using System.Collections.Generic;
using System.Linq;

namespace TakeSkipRope
{
    class TakeSkipRope
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> symbols = new List<string>(input.Length);
            List<int> numbers = new List<int>();


            for (int i = 0; i < input.Length; i++)
            {
                string current = input[i].ToString();
                int randomNum = 0;

                if (int.TryParse(current, out randomNum))
                {
                    randomNum = int.Parse(current);
                    numbers.Add(randomNum);
                }
                else
                {
                    symbols.Add(current);
                }
            }

            List<int> takeList = new List<int>(numbers.Count / 2);
            List<int> skipList = new List<int>(numbers.Count / 2);

            for (int i = 0; i < numbers.Count; i++)
            {
                if(i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }

            }

            List<string> result = new List<string>();

            for (int i = 0; i < takeList.Count; i++)
            {
                int take = takeList[i];
                int skip = skipList[i];

                if(take > symbols.Count)
                {
                    take = symbols.Count;
                }

                for (int j = 0; j < take; j++)
                {
                    string takenSymbol = symbols[j];
                    result.Add(takenSymbol);
                }

                    symbols.RemoveRange(0, take);
                if (skip > symbols.Count)
                {
                    skip = symbols.Count;
                }
                    symbols.RemoveRange(0, skip);
                
            }

            // Console.WriteLine(string.Join(" ", symbols));
            // Console.WriteLine(string.Join(" ", numbers));
            // Console.WriteLine(string.Join(" ", takeList));

            Console.WriteLine(string.Join("", result));
        }
    }
}
