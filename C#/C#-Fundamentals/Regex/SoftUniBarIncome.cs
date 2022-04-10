using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class SoftUniBarIncome
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string pattern = @"%([A-Z][a-z]+)%.*?<(\w+)>.*?[|](\d+)[|].*?(\d+\.?\d+?)[$]";
            Regex regex = new Regex(pattern);
            double sum = 0.0;

            while (command != "end of shift")
            {

                if (regex.IsMatch(command))
                {
                    Match match = regex.Match(command);
                    int quantity = int.Parse(match.Groups[3].Value);
                    double price = double.Parse(match.Groups[4].Value);
                    double result = quantity * price;
                    sum += result;

                    Console.WriteLine($"{ match.Groups[1]}: {match.Groups[2]} - {result:F2}");
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {sum:F2}");
        }
    }
}
