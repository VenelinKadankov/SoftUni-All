using System;
using System.Collections.Generic;
using System.Linq;

namespace BreakCycles
{
    class BreakCycles
    {
        private static Dictionary<string, List<string>> graph;
        private static List<Edg> edges;

        class Edg
        {
            public Edg(string first, string second)
            {
                this.First = first;
                this.Second = second;
            }

            public string First { get; set; }
            public string Second { get; set; }

            public override string ToString()
            {
                return $"{this.First} - {this.Second}";
            }
            public string ToStringReversed()
            {
                return $"{this.Second} - {this.First}";
            }
        }
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            graph = new Dictionary<string, List<string>>();
            edges = new List<Edg>();
            CreateGraph(count);

            edges = edges.OrderBy(a => a.First).ThenBy(a => a.Second).ToList();
            List<Edg> removedEdges = new List<Edg>();
            var notWanted = new HashSet<string>();

            foreach (var edge in edges)
            {
                string first = edge.First;
                string second = edge.Second;

                graph[first].Remove(second);
                graph[second].Remove(first);

                if (HasPath(first, second))
                {
                    if (notWanted.Contains(edge.ToString()))
                    {
                        continue;
                    }

                    removedEdges.Add(edge);
                    notWanted.Add(edge.ToStringReversed());
                }
                else
                {
                    graph[first].Add(second);
                    graph[second].Add(first);
                }
            }

            Console.WriteLine($"Edges to remove: {removedEdges.Count}");
            foreach (var edge in removedEdges)
            {
                var current = $"{edge.First} - {edge.Second}";
                if (notWanted.Contains(current))
                {
                    continue;
                }
                Console.WriteLine(current);
                var reversed = $"{edge.Second} - {edge.First}";
                notWanted.Add(reversed);
            }

        }

        private static bool HasPath(string first, string second)
        {
            var queue = new Queue<string>();
            queue.Enqueue(first);
            var visited = new HashSet<string>();

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == second)
                {
                    return true;
                }

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }
                    visited.Add(node);
                    queue.Enqueue(child);
                }


            }
            return false;
        }

        private static void CreateGraph(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string[] parts = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string node = parts[0];
                string[] children = parts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<string>());
                }

                foreach (var child in children)
                {
                    graph[node].Add(child);
                    edges.Add(new Edg(node, child));
                }

            }

        }
    }
}
