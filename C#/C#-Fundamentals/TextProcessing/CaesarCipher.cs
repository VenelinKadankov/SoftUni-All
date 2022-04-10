using System;
using System.Linq;

namespace CaesarCipher
{
    class CaesarCipher
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();
            int[] numbers = text.Select(a => Convert.ToInt32(a)).Select(a => a += 3).ToArray();
            char[] changed = numbers.Select(a => Convert.ToChar(a)).ToArray();
            string result = string.Join("", changed);

            Console.WriteLine(result);
        }
    }
}
