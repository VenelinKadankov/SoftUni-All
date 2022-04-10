using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    class ListOperations
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

            while (command[0].ToUpper() != "END")
            {
                switch (command[0].ToUpper())
                {
                    case "ADD":
                        numbers.Add(int.Parse(command[1]));
                        break;
                    case "INSERT":
                        int num = int.Parse(command[1]);
                        int index = int.Parse(command[2]);
                        if(index >= numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            numbers.Insert(index, num);
                        }

                        break;
                    case "REMOVE":
                        int item = int.Parse(command[1]);

                        if(item >= numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            numbers.RemoveAt(item);
                        }

                        break;
                    case "SHIFT":
                        int times = int.Parse(command[2]) % numbers.Count;

                        switch (command[1].ToUpper())
                        {
                            case "LEFT":
                                for (int i = 0; i < times; i++)
                                {
                                    int taken = numbers[0];
                                    numbers.Add(taken);
                                    numbers.RemoveAt(0);
                                }
                                break;
                            case "RIGHT":
                                for (int i = 0; i < times; i++)
                                {
                                    int taken = numbers[numbers.Count - 1];
                                    numbers.Insert(0, taken);
                                    numbers.RemoveAt(numbers.Count - 1);
                                }
                                break;
                            default:
                                break;
                        }
                        break;

                    default:
                        break;
                }

                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
