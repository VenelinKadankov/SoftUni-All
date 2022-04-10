using System;
using System.Collections.Generic;
using System.Linq;

namespace SnowWite
{
    class SnowWite
    {
        static void Main(string[] args)
        {

            Dictionary<string[], int> maybe = new Dictionary<string[], int>();
            Dictionary<Dictionary<string, string>, int> dwarfs = new Dictionary<Dictionary<string, string>, int>();
            string command = Console.ReadLine();

            while (command!= "Once upon a time")
            {
                string[] tokens = command.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0], color = tokens[1];
                int points = int.Parse(tokens[2]);
                string[] arr = new string[] { name, color };
                Dictionary<string, string> current = new Dictionary<string, string> ();
                current.Add(name, color);

                if (maybe.ContainsKey(arr))
                {
                    if (maybe[arr] < points)
                    {
                        maybe[arr] = points;
                    }
                }

              //  if (dwarfs.ContainsKey(name,color))  //(current.SequenceEquals(dwarfs[current]))
               // {
               //     if (dwarfs[current] < points) 
               //     {
                //        dwarfs[current] = points;
                //    }
               // }
                else
                {
                    maybe.Add(arr, points);
                   // dwarfs.Add(current, points);

                   // foreach (var item in dwarfs)
                   // {
                     //   if (item.Key.ContainsKey(name))
                    //    {
                    //
                    //    }
                   // }
                }


                command = Console.ReadLine();
            }

         //   var result = dwarfs.OrderByDescending(a => a.Value)
          //      .ThenBy(b => b.Key.Count())
          //      .ToDictionary(pair => pair.Key, pair => pair.Value);
//
            var res = maybe.OrderByDescending(a => a.Value).ThenByDescending(b => b.Key[1].Count()).ToDictionary(pair => pair.Key, pair => pair.Value);

         //   foreach (var item in result)
         //   {

          //      Console.WriteLine($"{string.Join("   ", item.Key)}");
          //  }

            foreach (var item in maybe)
            {
                Console.WriteLine($"{string.Join("---", item.Key)} +++++++ {item.Value}");
            }
        }


        public static bool DictionaryComparer(List<Dictionary<string, string>> a, Dictionary<string, string> b)
        {

            for (int i = 0; i < a.Count; i++)
            {
                Dictionary<string, string> y = new Dictionary<string, string>();
                if (a.Count != b.Count)
                {
                    return false;
                }

                foreach (var item in y)
                {
                    if (!b.ContainsKey(item.Key))
                    {
                        return false;
                    }

                    if (!b.ContainsValue(item.Value))
                    {
                        return false;
                    }
                }
            }


            return true;
        }
    }
}
