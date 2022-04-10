using System;
using System.Linq;

namespace ArrayManipulator
{
    class ArrayManipulator
    {
        static void Main(string[] args)
        {

            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] result = array; //new int[array.Length];

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] actions = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int index = 0;
                string type = "";
                int count = 0;



                if (actions[0] == "exchange")
                {
                    index = int.Parse(actions[1]);

                    if (index >= array.Length || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        result = ExchangeElements(result, index);
                    }

                }

                if (actions[0] == "max")
                {
                    type = actions[1];
                    int searchedMaxIndex = FindMaxNumber(result, type);

                    if (searchedMaxIndex != -1)
                    {
                        Console.WriteLine(searchedMaxIndex);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }

                }

                if (actions[0] == "min")
                {
                    type = actions[1];
                    int searchedMinIndex = FindMinNumber(result, type);

                    if (searchedMinIndex != -1)
                    {
                        Console.WriteLine(searchedMinIndex);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                }

                if (actions[0] == "first")
                {
                    count = int.Parse(actions[1]);
                    type = actions[2];
                    string searchedFirst = FindFirst(result, count, type);

                    int[] firstArr = searchedFirst
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

                    if (count > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        Console.WriteLine($"[{string.Join(", ", firstArr)}]");
                    }

                }

                if (actions[0] == "last")
                {
                    count = int.Parse(actions[1]);
                    type = actions[2];
                    string searchedLast = FindLast(result, count, type);

                    int[] lastArr = searchedLast
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .Reverse()
                                .ToArray();

                    if (count > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        Console.WriteLine($"[{string.Join(", ", lastArr)}]");
                        //Console.WriteLine(lastArr);
                    }

                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", result)}]");

        }


        public static int[] ExchangeElements(int[] arr, int index)
        {

            if (index >= arr.Length)
            {
                return arr;
            }

            int arrayLength = arr.Length;
            int[] resultArr = new int[arrayLength];
            int[] firstHalf = arr.TakeLast(arrayLength - 1 - index).ToArray(); //new int[arrayLength - (index + 1)];
            int[] secondHalf = arr.Take(index + 1).ToArray();     //new int[index + 1];

            for (int i = 0; i < firstHalf.Length; i++)
            {
                resultArr[i] = firstHalf[i];
            }

            int counter = 0;

            for (int j = firstHalf.Length; j < arrayLength; j++)
            {
                resultArr[j] = secondHalf[counter];
                counter++;
            }

            return resultArr;
        }

        public static int FindMaxNumber(int[] arr, string type)
        {
            int maxOdd = int.MinValue;
            int maxEven = int.MinValue;
            int searchedIndex = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                int num = arr[i];
                if (type == "odd")
                {
                    if (num % 2 != 0)
                    {
                        if (num >= maxOdd)
                        {
                            maxOdd = num;
                            searchedIndex = i;
                        }
                    }
                }
                else if (type == "even")
                {
                    if (num % 2 == 0)
                    {
                        if (num >= maxEven)
                        {
                            maxEven = num;
                            searchedIndex = i;
                        }
                    }

                }
            }

            return searchedIndex;
        }

        public static int FindMinNumber(int[] arr, string type)
        {
            int minOdd = int.MaxValue;
            int minEven = int.MaxValue;
            int searchedIndex = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                int num = arr[i];
                if (type == "odd")
                {
                    if (num % 2 != 0)
                    {
                        if (num <= minOdd)
                        {
                            minOdd = num;
                            searchedIndex = i;
                        }
                    }
                }
                else if (type == "even")
                {
                    if (num % 2 == 0)
                    {
                        if (num <= minEven)
                        {
                            minEven = num;
                            searchedIndex = i;
                        }
                    }

                }
            }

            return searchedIndex;
        }

        public static string FindFirst(int[] arr, int count, string type)
        {
            string firstEven = "";
            string firstOdd = "";
            int counter = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int num = arr[i];

                if (type == "odd")
                {
                    if (num % 2 != 0)
                    {
                        firstOdd += num + " ";
                        counter++;
                    }
                }
                else
                {
                    if (num % 2 == 0)
                    {
                        firstEven += num + " ";
                        counter++;
                    }
                }

                if (counter >= count)
                {
                    break;
                }
            }

            if (type == "odd")
            {
                return firstOdd;
            }
            else
            {
                return firstEven;
            }

        }

        public static string FindLast(int[] arr, int count, string type)
        {
            string lastEven = "";
            string lastOdd = "";
            int counter = 0;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int num = arr[i];

                if (type == "odd")
                {
                    if (num % 2 != 0)
                    {
                        lastOdd += num + " ";
                        counter++;
                    }
                }
                else
                {
                    if (num % 2 == 0)
                    {
                        lastEven += num + " ";
                        counter++;
                    }
                }

                if (counter >= count)
                {
                    break;
                }
            }

            if (type == "odd")
            {
                return lastOdd;
            }
            else
            {
                return lastEven;
            }

        }
    }
}
