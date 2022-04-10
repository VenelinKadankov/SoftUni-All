using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Furniture
    {
        static void Main(string[] args)
        {
            string pattern = @">>([A-Za-z]+)<<(\d+\.?\d*?)!(\d+)";
            Regex regex = new Regex(pattern);
            string command = Console.ReadLine();
            double sum = 0.0;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Bought furniture:");

            while (command != "Purchase")
            {
                if (regex.IsMatch(command))
                {
                    Match match = regex.Match(command);
                    double value = double.Parse(match.Groups[2].Value);
                    int count = int.Parse(match.Groups[3].Value);
                    sum += value * count;
                    sb.AppendLine(match.Groups[1].Value);
                }             

                command = Console.ReadLine();
            }

            sb.AppendLine($"Total money spend: {sum:F2}");
            string output = sb.ToString();
            Console.WriteLine(output);
        }
    }
}
