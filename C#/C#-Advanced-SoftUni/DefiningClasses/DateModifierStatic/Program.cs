using System;

namespace DateModifierStatic
{
    public class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            int result = DateModifier.CalcDifference(first, second);
            Console.WriteLine(result);
        }
    }
}
