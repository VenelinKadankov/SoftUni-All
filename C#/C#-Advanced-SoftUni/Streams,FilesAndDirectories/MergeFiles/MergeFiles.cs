using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MergeFiles
{
    class MergeFiles
    {
        static void Main(string[] args)
        {
            List<char> first = new List<char>();
            List<char> second = new List<char>();

            using (FileStream reader = new FileStream("../../../file1.txt", FileMode.Open))
            {
                byte[] buffer = new byte[1];
                reader.Read(buffer, 0, buffer.Length);

                while (buffer[0] != 0)
                {
                    first.Add((char)buffer[0]);
                    reader.Read(buffer, 0, buffer.Length);
                }
            }

            using (FileStream reader = new FileStream("../../../file2.txt", FileMode.Open))
            {
                byte[] buffer = new byte[1];
                reader.Read(buffer, 0, buffer.Length);

                while (buffer[0] != 0)
                {
                    second.Add((char)buffer[0]);
                    reader.Read(buffer, 0, buffer.Length);
                }
            }
            ;
            List<char> result = first.Union(second).ToList();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
