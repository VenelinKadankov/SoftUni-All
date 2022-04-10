using System;
using System.Collections.Generic;
using System.Linq;

namespace DistanceBetweenVertices
{
    class DistanceBetweenVertices
    {
        private static Dictionary<int, List<int>> graph;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            graph = ReadGraph(n);

            for (int i = 0; i < p; i++)
            {
                int[] line = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int source = line[0];
                int destination = line[1];

                int steps = BFS(source, destination);
                Console.WriteLine("{" + $"{source}, {destination}" + "}" + $" -> {steps}");
            }
        }

        private static int BFS(int source, int destination)
        {
            Dictionary<int, int> countSteps = new Dictionary<int, int> {{ source, 0 }};
            var queue = new Queue<int>();
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return countSteps[node];
                }

                foreach (var child in graph[node])
                {
                    if (countSteps.ContainsKey(child))
                    {
                        continue;
                    }

                    queue.Enqueue(child);
                    countSteps[child] = countSteps[node] + 1;

                }


            }


            return -1;
        }

        private static Dictionary<int, List<int>> ReadGraph(int n)
        {
            Dictionary<int, List<int>> result = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(":");
                int node = int.Parse(line[0]);

                if (line.Length == 1)
                {
                    result.Add(node, new List<int>());
                }
                else
                {
                    var children = line[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                    result.Add(node, children);
                }
            }

            return result;
        }
    }
}
