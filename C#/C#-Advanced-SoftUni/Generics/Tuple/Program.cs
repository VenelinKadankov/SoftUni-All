using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string first = Console.ReadLine();
            //string name = first.Substring(0, first.LastIndexOf(" "));
            //string address = first.Substring(first.LastIndexOf(" ") + 1);
            //string second = Console.ReadLine();
            //string shortName = second.Substring(0, second.LastIndexOf(" "));
            //int beers = int.Parse(second.Substring(second.LastIndexOf(" ") + 1));
            //string third = Console.ReadLine();
            //int number = int.Parse(third.Substring(0, third.LastIndexOf(" ")));
            //double drob = double.Parse(third.Substring(third.LastIndexOf(" ") + 1));

            string[] first = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = string.Join(" ", first[0], first[1]);
            string address = first[2];
            string town = string.Join(" ", first.Skip(3));
            string[] second = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string shortName = second[0];
            int beers = int.Parse(second[1]);
            string condition = second[2];            
            string[] third = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string thirdName = third[0];
            double drob = double.Parse(third[1]);
            string bankName = third[2];
            bool isDrunk = false;

            if (condition == "drunk")
            {
                isDrunk = true;
            }

            Tuple<string, string, string> firstOne = new Tuple<string, string, string>(name, address, town);
            Tuple<string, int, bool> secondOne = new Tuple<string, int, bool>(shortName, beers, isDrunk);
            Tuple<string, double, string> thirdOne = new Tuple<string, double, string>(thirdName, drob, bankName);

            Console.WriteLine($"{firstOne.Key} -> {firstOne.Quantity} -> {firstOne.Item}");
            Console.WriteLine($"{secondOne.Key} -> {secondOne.Quantity} -> {secondOne.Item}");
            Console.WriteLine($"{thirdOne.Key} -> {thirdOne.Quantity} -> {thirdOne.Item}");

        }
    }
}
