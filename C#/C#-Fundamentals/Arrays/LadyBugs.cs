using System;
using System.Linq;

namespace LadyBugs
{
    class LadyBugs
    {
        static void Main(string[] args)
        {
            int[] field = new int[int.Parse(Console.ReadLine())];
            int[] startBugs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < startBugs.Length; i++)
            {
                int bug = startBugs[i];

                if (field.Length > bug && bug >= 0 )
                {
                    field[bug] = 1;
                }
            }

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commandArray = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int startIndex = int.Parse(commandArray[0]), flyLength = int.Parse(commandArray[2]);
                string direction = commandArray[1];

                if (0 <= startIndex && startIndex < field.Length) 
                {
                    if (field[startIndex] != 0 && direction == "right")
                    {
                        if (startIndex + flyLength > field.Length - 1)
                        {
                            field[startIndex] = 0;
                        }
                        else if (field[startIndex + flyLength] == 0 && startIndex + flyLength <= field.Length - 1)
                        {
                            field[startIndex] = 0;
                            field[startIndex + flyLength] = 1;
                        }
                        else if (field[startIndex + flyLength] == 1)
                        {
                            int endIndex = startIndex + flyLength;
                            while (field[endIndex] == 1)
                            {
                                field[startIndex] = 0;
                                endIndex += flyLength;

                                if (endIndex >= field.Length)
                                {
                                    break;
                                }

                                if (field[endIndex] == 0)
                                {
                                    field[endIndex] = 1;
                                    break;
                                }


                            }

                        }

                    }
                    else if (field[startIndex] != 0 && direction == "left")
                    {

                        if (startIndex - flyLength < 0)
                        {
                            field[startIndex] = 0;
                        }
                        else if (field[startIndex - flyLength] == 0 && startIndex - flyLength >= 0)
                        {
                            field[startIndex] = 0;
                            field[startIndex - flyLength] = 1;
                        }
                        else if (field[startIndex - flyLength] == 1)
                        {
                            int endIndex = startIndex - flyLength;
                            while (field[endIndex] == 1)
                            {
                                field[startIndex] = 0;
                                endIndex -= flyLength;

                                if (endIndex < 0)
                                {
                                    break;
                                }

                                if (field[endIndex] == 0)
                                {
                                    field[endIndex] = 1;
                                    break;
                                }

                            }

                        }

                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}
