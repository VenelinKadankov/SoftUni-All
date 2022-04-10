using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class StudentAcademy
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> register = new Dictionary<string, List<double>>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (register.ContainsKey(name))
                {
                    register[name].Add(grade);
                }
                else
                {
                    register.Add(name, new List<double>());
                    register[name].Add(grade);
                }
            }

            Dictionary<string, double> filtered = register.Where(a => a.Value.Average() >= 4.50).ToDictionary(pair => pair.Key, pair => pair.Value.Average());

            var result = filtered.OrderByDescending(a => a.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value:F2}");
            }
        }
    }
}

