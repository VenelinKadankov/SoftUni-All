using System;

namespace LongerLine
{
    class LongerLine
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double side1A = Math.Abs(x1) + Math.Abs(x3);
            double side2A = Math.Abs(x2) + Math.Abs(x4);
            double side1B = Math.Abs(y1) + Math.Abs(y1);
            double side2B = Math.Abs(y2) + Math.Abs(y4);

            double distanceX1 = CalculateDistance(x1, x2);
            double distanceX2 = CalculateDistance(x3, x4);
            double distanceY1 = CalculateDistance(y1, y2);
            double distanceY2 = CalculateDistance(y3, y4);
            double firstLine = CalculateDistance(side1A, side2A);
            double secondLine = CalculateDistance(side1B, side2B);

            if(firstLine >= secondLine)
            {
                if(distanceX1 <= distanceX2)
                {
                    Console.WriteLine($"({x1}, {x2})({x3}, {x4})");
                } 
                else
                {
                    Console.WriteLine($"({x3}, {x4})({x1}, {x2})");
                }
                
            }
            else
            {
                if(distanceY1 <= distanceY2)
                {
                    Console.WriteLine($"({y1}, {y2})({y3}, {y4})");
                }
                else
                {
                    Console.WriteLine($"({y3}, {y4})({y1}, {y2})");
                }
                
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
