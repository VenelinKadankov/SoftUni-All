using System;

namespace DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            DateModifier output = new DateModifier();
            int result = output.CalcDifference(first, second);
            Console.WriteLine(result);
        }
    }
}
