using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        //private List<Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Ingredients = new List<Ingredient>();
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
        }

        public List<Ingredient> Ingredients { get; set; }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel => this.Ingredients.Sum(x => x.Alcohol);

        public void Add(Ingredient ingredient)
        {
            var volume = this.Ingredients.Sum(x => x.Quantity);
            var alcohol = this.Ingredients.Sum(x => x.Alcohol);

            if (!Ingredients.Any(x => x.Name == ingredient.Name && 
                              volume + ingredient.Quantity <= Capacity && 
                              alcohol + ingredient.Alcohol <= MaxAlcoholLevel))
            {
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            var ing = Ingredients.FirstOrDefault(x => x.Name == name);

            return this.Ingredients.Remove(ing);
        }

        public Ingredient FindIngredient(string name)
        {
            return this.Ingredients.FirstOrDefault(x => x.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            var maxAlcohol = this.Ingredients.Max(x => x.Alcohol);

            return this.Ingredients.FirstOrDefault(x => x.Alcohol == maxAlcohol);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var item in this.Ingredients)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().Trim();
        }
    }
}
