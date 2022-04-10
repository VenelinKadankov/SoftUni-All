using System;
using System.Collections.Generic;
using System.Linq;

namespace TopologicalSorting
{
    class TopologicalSorting
    {
        public static Dictionary<string, List<string>> graph;
        public static Dictionary<string, int> predecessorCount;
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            predecessorCount = new Dictionary<string, int>();
            graph = new Dictionary<string, List<string>>();
            graph = ReadGraph(n);
            predecessorCount = GetPredecessorCount();
            //graph = ReadGraph(n);
            //List<string> sorted = 
             TopologicalSort();
        }

        public static void TopologicalSort()// List<string> TopologicalSort()
        {
            var sorted = new List<string>();
            while (predecessorCount.Count > 0)
            {
                var nodeToRemove = predecessorCount.FirstOrDefault(a => a.Value == 0);

                if (nodeToRemove.Key == null)
                {
                    break;
                }

                var node = nodeToRemove.Key;
                var children = graph[node];
                sorted.Add(node);

                foreach (var child in children)
                {
                    predecessorCount[child] -= 1;
                }

                predecessorCount.Remove(nodeToRemove.Key);

            }

            if (predecessorCount.Count > 0)
            {
                Console.WriteLine("Invalid topological sorting");
            }
            else
            {
                Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
            }
           // return sorted;
        }

        public static Dictionary<string, List<string>> ReadGraph(int n)
        {
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                //string node = line.Substring(0, line.IndexOf(" " + 1));
                string[] tokens = line.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string node = tokens[0].Trim();
                if (tokens.Length > 1)
                {
                    List<string> paths = tokens[1].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(a => a.Trim()).ToList();
                    if (!graph.ContainsKey(node))
                    {
                      //  if (graph[node][0] != "")
                     //   {


                            graph.Add(node, new List<string>());
                        for (int j = 0; j < paths.Count; j++)
                        {
                            if (paths[j] != "")
                            {
                                graph[node].Add(paths[j]);
                            }
                        }
                           // graph[node] = paths;
                       // }
                    }
                }
                else
                {
                    graph.Add(node, new List<string>());
                }

            }

            return graph;
        }

        public static Dictionary<string, int> GetPredecessorCount()
        {
            var result = new Dictionary<string, int>();

            foreach (var node in graph)
            {
                
                string key = node.Key;
                List<string> children = node.Value;

                if (!result.ContainsKey(key))
                {
                    result.Add(key, 0);
                }

                foreach (var child in children)
                {
                    if (!result.ContainsKey(child))
                    {
                        if (child != "")
                        {


                            result.Add(child, 1);
                        }
                    }
                    else
                    {
                        result[child] += 1;
                    }
                }
            }

            return result;
        }
    }
}
