using System;
using System.Collections.Generic;

namespace TheStoryTelling
{
    class TheStoryTelling
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static Stack<string> output;
        static void Main(string[] args)
        {
            graph = ReadGraph();
            visited = new HashSet<string>();
            output = new Stack<string>();

            foreach (var node in graph.Keys)
            {
                DFS(node);
            }

            Console.WriteLine(string.Join(" ", output));
        }

        private static void DFS(string node)
        {

            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            output.Push(node);

        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var result = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();

            while (command?.ToLower() != "end")
            {
                string[] parts = command.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string node = parts[0].Trim();

                if (!result.ContainsKey(node))
                {
                    result.Add(node, new List<string>());
                }

                if (parts.Length > 1)
                {
                    string[] children = parts[1].Trim().Split();
                    result[node].AddRange(children);
                }

                command = Console.ReadLine();
            }

            return result;
        }
    }
}
