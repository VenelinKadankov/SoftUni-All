using System;

namespace GenericBoxOfString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int text = int.Parse(Console.ReadLine());
                var result = new Box<int>(text);
                Console.WriteLine(result);
            }
        }
    }
}
