using System;
using System.Collections.Generic;

namespace CompanyUsers
{
    class CompanyUsers
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> register = new SortedDictionary<string, List<string>>();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string company = tokens[0], id = tokens[1];

                if (register.ContainsKey(company))
                {

                    if (!register[company].Contains(id))
                    {
                        register[company].Add(id);
                    }

                }
                else
                {
                    register.Add(company, new List<string>());
                    register[company].Add(id);
                }

                command = Console.ReadLine();
            }

            foreach (var item in register)
            {
                Console.WriteLine(item.Key);

                foreach (var name in item.Value)
                {
                    Console.WriteLine($"-- {name}");
                }
            }

        }
    }
}
