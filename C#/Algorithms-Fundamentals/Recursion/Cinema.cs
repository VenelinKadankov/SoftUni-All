using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema
{
    class Cinema
    {
        public static List<string> names;
        public static string[] seats;
        public static HashSet<int> taken;
        static void Main(string[] args)
        {
            names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
           // string command = Console.ReadLine();
            taken = new HashSet<int>();
            seats = new string[names.Count];

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "generate")
                {
                    break;
                }

                string[] tokens = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int seat = int.Parse(tokens[1]) - 1;

                taken.Add(seat);
                seats[seat] = name;
                names.Remove(name);
               // Permute(0);

            }
            Permute(0);
            // Console.WriteLine(string.Join(Environment.NewLine, taken));
        }

        private static void Permute(int index)
        {
            if (index >= names.Count)
            {
                var indexName = 0;

                for (int i = 0; i < seats.Length; i++)
                {
                    if (taken.Contains(i))
                    {
                        continue;
                    }


                    seats[i] = names[indexName];
                    indexName++;
         
                }

                Console.WriteLine(string.Join(" ", seats));
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < names.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int elementIndex, int i)
        {
            var toSwap = names[elementIndex];
            names[elementIndex] = names[i];
            names[i] = toSwap;
        }
    }
}
