using System;

namespace ExtractFile
{
    class ExtractFile
    {
        static void Main(string[] args)
        {
            string[] path = Console.ReadLine().Split("\\", StringSplitOptions.RemoveEmptyEntries);
            string[] last2 = path[path.Length - 1].Split(".", StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"File name: {last2[0]}");
            Console.WriteLine($"File extension: {last2[1]}");
        }
    }
}
