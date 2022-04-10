using System;
using System.Collections.Generic;
using System.Linq;

namespace RoadReconstruction
{
    class RoadReconstruction
    {
        private static Dictionary<int, List<int>> graph;
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int paths = int.Parse(Console.ReadLine());
            graph = CreateGraph(nodes, paths).OrderBy(a => a.Value[0]).ToDictionary(a => a.Key, a => a.Value);

            Console.WriteLine("Important streets:");
            while (ContainsElement(graph))
            {
              //  Console.WriteLine("yes");
                var conected = graph.Take(1).ToDictionary(b =>b.Key, b => b.Value);
                int[] tokens = conected.Keys.ToArray();
                List<int>[] lists = conected.Values.ToArray();
                int fromWhere = lists[0][1];
                int city = tokens[0];

                graph.Remove(city);

                foreach (var node in graph.Where(a => a.Value.Skip(1).Contains(city)))
                {
                    node.Value[0]--;
                    node.Value.Remove(city);
                }

                ;

                Console.WriteLine($"{Math.Min(city, fromWhere)} {Math.Max(city, fromWhere)}");
                graph = graph.OrderBy(a => a.Value[0]).ToDictionary(a => a.Key, a => a.Value);
                // break;
            }
        }

        private static bool ContainsElement(Dictionary<int, List<int>> graph)
        {
            return graph.Any(a => a.Value[0] == 1);
        }

        private static Dictionary<int, List<int>> CreateGraph(int nodes, int paths)
        {
            var result = new Dictionary<int, List<int>>();
            for (int n = 0; n < nodes; n++)
            {
                result.Add(n, new List<int>());
                result[n].Add(0);
            }

            for (int p = 0; p < paths; p++)
            {
                int[] cities = Console.ReadLine()
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int first = cities[0];
                int second = cities[1];

                if (result.ContainsKey(first))
                {
                    result[first][0]++;
                    result[first].Add(second);
                }
                if (result.ContainsKey(second))
                {
                    result[second][0]++;
                    result[second].Add(first);
                }
            }

            return result;
        }
    }
}
