using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AddAstra
{
    class AddAstra
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string pattern = @"([\|#])([A-Za-z\s]+)\1(\d{2}\/\d{2}\/\d{2})\1([\d]{1,4}|10000)\1";
            Regex regex = new Regex(pattern);
            int caloriesSum = 0;
            List<Food> products = new List<Food>();

            while (regex.IsMatch(message))
            {
                Match current = regex.Match(message);
                string product = current.Value;
                message = message.Remove(message.IndexOf(product), product.Length);
                string name = current.Groups[2].Value;
                string date = current.Groups[3].Value;
                int calories = int.Parse(current.Groups[4].Value);

                Food food = new Food (name, date, calories);
                products.Add(food);
            }

            foreach (var item in products)
            {
                caloriesSum += item.Calories;
            }

            int days = caloriesSum / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (var item in products)
            {
                Console.WriteLine($"Item: {item.Name}, Best before: {item.Date}, Nutrition: {item.Calories}");
            }

        }

        class Food
        {
            public Food(string name, string date, int calories)
            {
                Name = name;
                Date = date;
                Calories = calories;
            }

            public string Name { get; set; }
            public string Date { get; set; }
            public int Calories { get; set; }
        }
    }
}
