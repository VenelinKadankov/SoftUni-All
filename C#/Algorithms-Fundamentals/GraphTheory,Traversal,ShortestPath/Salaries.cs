using System;
using System.Collections.Generic;

namespace Salaries
{
    class Salaries
    {
        private static List<int>[] graph;
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            graph = ReadGraph(count);

            int totalSalary = 0;

            for (int node = 0; node < graph.Length; node++)
            {
                int salary = CalculateSalary(node);
                totalSalary += salary;
            }

            Console.WriteLine(totalSalary);
        }

        private static int CalculateSalary(int node)
        {
            
            if (graph[node].Count == 0)
            {
                return 1;
            }
            int salary = 0;

            foreach (var child in graph[node])
            {
                 salary += CalculateSalary(child);
            }

            return salary;
        }

        private static List<int>[] ReadGraph(int count)
        {
            List<int>[] result = new List<int>[count];

            for (int i = 0; i < count; i++)
            {
                string line = Console.ReadLine();
                List<int> children = new List<int>();

                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'Y')
                    {
                        children.Add(j);
                    }
                }

                result[i] = children;
            }

            return result;
        }
    }
}
