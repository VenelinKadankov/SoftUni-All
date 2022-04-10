using System;
using System.Text;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class FancyBarcodes
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string pattern = @"@#+[A-Z][A-Za-z\d]{4,}[A-Z]@#+";
            Regex regex = new Regex(pattern);
            string nums = @"\d";
            Regex numRegex = new Regex(nums);

            for (int i = 0; i < count; i++)
            {
                string barcode = Console.ReadLine();

                if (regex.IsMatch(barcode))
                {
                    Match match = regex.Match(barcode);
                    string group = "00";

                    if (numRegex.IsMatch(barcode))
                    {
                        MatchCollection matches = numRegex.Matches(barcode);
                        StringBuilder code = new StringBuilder();

                        foreach (Match item in matches)
                        {
                            code.Append(item.Value);
                        }

                        group = code.ToString();
                    }

                    Console.WriteLine($"Product group: {group}");

                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
