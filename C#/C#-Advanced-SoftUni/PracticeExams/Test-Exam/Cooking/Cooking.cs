using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Cooking
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> ingredients = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string, int> foods = new Dictionary<string, int>();
            foods.Add("Bread", 0);
            foods.Add("Cake", 0);
            foods.Add("Pastry", 0);
            foods.Add("Fruit Pie", 0);

            int rounds = Math.Min(liquids.Count, ingredients.Count);

            while (ingredients.Count > 0 && liquids.Count > 0)
            {
                int currentLiquid = liquids.Dequeue();
                int currentIngredient = ingredients.Pop();
                int result = currentIngredient + currentLiquid;
                string key = string.Empty;

                switch (result)
                {
                    case 25:
                        key = "Bread";
                        break;                    
                    case 50:
                        key = "Cake";
                        break;                    
                    case 75:
                        key = "Pastry";
                        break;                    
                    case 100:
                        key = "Fruit Pie";
                        break;

                    default:
                        ingredients.Push(currentIngredient + 3);
                        break;
                }

                if (key != string.Empty)
                {
                    foods[key]++;
                }
            }

            if (!foods.Values.Any(a => a == 0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count > 0)
            {
                string result = string.Join(", ", liquids.ToArray());
                Console.WriteLine($"Liquids left: {result}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Count > 0)
            {
                string result = string.Join(", ", ingredients.ToArray());
                Console.WriteLine($"Ingredients left: {result}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foods = foods.OrderBy(a => a.Key).ToDictionary(a => a.Key, a => a.Value);
            foreach (var item in foods)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            ;
        }
    }
}
