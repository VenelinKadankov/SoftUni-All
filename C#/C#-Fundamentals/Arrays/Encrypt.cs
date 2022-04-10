using System;
using System.Collections.Immutable;

namespace EncryptSortPrint
{
    class Encrypt
    {
        static void Main(string[] args)
        {
            int numberStrings = int.Parse(Console.ReadLine());
            int[] valuesArray = new int[numberStrings];

            for (int i = 0; i < numberStrings; i++)
            {
                string name = Console.ReadLine();
                int sum = 0;

                for (int j = 0; j < name.Length; j++)
                {
                    char character = name[j];
                    int value = (int)character;
                    bool firstCondition = character == 'a' || character == 'e' || character == 'o' || character == 'u' || character == 'i'
                        || character == 'A' || character == 'E' || character == 'O' || character == 'U' || character == 'I';

                    if (character == 'a' || character == 'e' || character == 'o' || character == 'u' || character == 'i' 
                        || character == 'A' || character == 'E' || character == 'O' || character == 'U' || character == 'I')
                    {
                        value *= name.Length;
                    } 
                    else
                    {
                        value /= name.Length;
                    }

                    sum += value;

                }

                valuesArray[i] = sum;
            }

            Array.Sort(valuesArray);
            foreach(int element in valuesArray)
            {
                Console.WriteLine(element);
            }
        }
    }
}
