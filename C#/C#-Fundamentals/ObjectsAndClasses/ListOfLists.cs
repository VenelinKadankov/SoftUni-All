using System;
using System.Collections.Generic;

namespace ListOfLists
{
    class ListOfLists
    {
        static void Main(string[] args)
        {
            List<int> first = new List<int> { 2, 3, 4, 5, 6, 7, 8, 2, 3, 4, 5, 3, 2, 4, 6, 7, 8};
            List<int> coppied = first.GetRange(0, first.Count - 1);

            //first.RemoveRange(0, 5);
            Console.WriteLine(string.Join("-", first));
            Console.WriteLine(string.Join("+", coppied));
            List<List<int>> result = new List<List<int>>();

            while(first.Count > 0)
            {
                int num = first[0];
                List<int> newList = new List<int>();
                newList.Add(num);
                first.Remove(num);

                for (int i = 0; i < coppied.Count; i++)
                {
                    int current = first[i];

                    if (current == num)
                    {
                        newList.Add(current);
                        first.Remove(current);
                    }
                }

                result.Add(newList);
                coppied = first;
                

            }
        }
    }
}
