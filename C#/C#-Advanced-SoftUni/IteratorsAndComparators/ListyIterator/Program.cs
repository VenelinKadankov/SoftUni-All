using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var list = new ListyIterator<string>(input.Skip(1).ToList());

            string command = Console.ReadLine();

            while (command?.ToUpper() != "END")
            {
                switch (command)
                {
                    case "Move":
                        bool res = list.Move();
                        Console.WriteLine(res);
                        break;
                    case "Print":
                        list.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "PrintAll":
                        list.PrintAll();
                        break;

                    default:
                        break;
                }


                command = Console.ReadLine();
            }
        }
    }
}
