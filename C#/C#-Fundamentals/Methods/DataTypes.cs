using System;
using System.Diagnostics.CodeAnalysis;

namespace MethodsExtra
{
    class DataTypes
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string num = Console.ReadLine();

            int integerNum = 0;
            double realNum = 0.0;

            if (type == "int" && int.TryParse(num, out integerNum))
            {
                integerNum = int.Parse(num);
                int result = TypeChecker(integerNum);
                Console.WriteLine(result);
            }
            else if (type == "real" && double.TryParse(num, out realNum))
            {
                realNum = double.Parse(num);
                double result = TypeChecker(realNum);
                Console.WriteLine($"{result:F2}");
            }
            else if (type == "string")
            {
                string result = TypeChecker(num);
                Console.WriteLine(result);
            }

        }

        private static int TypeChecker(int num)
        {
            int sum = num * 2;
            //Console.WriteLine(sum);

            return sum;
        }

        private static double TypeChecker(double num)
        {
            double sum = num * 1.5;
            // Console.WriteLine($"{sum:f2}");

            return sum;
        }

        private static string TypeChecker(string text)
        {
            //Console.WriteLine($"${text}$");
            string sum = $"${text}$";
            return sum;
        }
    }
}
