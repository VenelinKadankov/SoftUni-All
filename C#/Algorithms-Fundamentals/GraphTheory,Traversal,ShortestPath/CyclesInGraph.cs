using System;
using System.Collections.Generic;

namespace CyclesInGraph
{
    class CyclesInGraph
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;
        static void Main(string[] args)
        {
            graph = ReadGraph();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();

            foreach (var node in graph.Keys)
            {
                try
                {
                    DFS(node);
                }
                catch(InvalidOperationException)
                {
                    Console.WriteLine("Acyclic: No");
                    return;
                }
                
            }
            Console.WriteLine("Acyclic: Yes");

        }

        private static void DFS(string node)
        {
            if (cycles.Contains(node))
            {
                throw new InvalidOperationException();
            }

            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);
            cycles.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }
            visited.Remove(node);
            cycles.Remove(node);
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var result = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();

            while (command?.ToLower() != "end")
            {
                string[] nodes = command.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string parent = nodes[0];
                string child = nodes[1];
                if (!result.ContainsKey(parent))
                {
                    result.Add(parent, new List<string>());

                }

                if (!result.ContainsKey(child))
                {
                    result.Add(child, new List<string>());
                }

                result[parent].Add(child);

                command = Console.ReadLine();
            }

            return result;
        }
    }
}
