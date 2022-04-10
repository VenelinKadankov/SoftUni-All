using System;
using System.Collections.Generic;
using System.Linq;

namespace OperationsAgain
{
    class OperationsAgain
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while(command[0].ToUpper() != "END")
            {


                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            Console.WriteLine(string.Join(' ', numbers));

        }
    }
}
