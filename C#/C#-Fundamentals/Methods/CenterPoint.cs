using System;

namespace CenterPoint
{
    public class CenterPoint
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double firstDistance = CalculateDistance(x1, x2);
            double secondDistance = CalculateDistance(y1, y2);

            if (firstDistance <= secondDistance)
            {
                Console.WriteLine($"({x1}, {x2})");
            } 
            else
            {
                Console.WriteLine($"({y1}, {y2})");
            }
        }

        public static double CalculateDistance(double a, double b)
        {
            double sum = 0.0D;
            sum = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

            return sum;
        }
    }
}
