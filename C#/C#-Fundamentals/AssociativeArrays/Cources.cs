using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> register = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();

            while (command?.ToLower() != "end")
            {
                string[] tokens = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string subject = tokens[0], name = tokens[1];

                if (register.ContainsKey(subject))
                {
                    register[subject].Add(name);
                }
                else
                {
                    register.Add(subject, new List<string>());
                    register[subject].Add(name);
                }

                command = Console.ReadLine();
            }

            Dictionary<string, List<string>> orderedRegister = register.OrderByDescending(a => a.Value.Count)
                                                                       .ToDictionary(pair => pair.Key, pair => pair.Value);


            foreach (var item in orderedRegister)
            {
                Console.WriteLine(item.Key + ": " + item.Value.Count);
                var res = item.Value.OrderBy(a => a).ToList();

                foreach (var name in res)
                {
                    Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}
