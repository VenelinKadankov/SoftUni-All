using System.Collections.Generic;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer()
        {

        }

        public Trainer(string name, string pokemonName, string element, int health)
        {
            Name = name;
            NumberBadges = 0;
            PokemonList = new List<Pokemon>
            {
                new Pokemon(pokemonName, element, health)
            };
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int numberBadges;

        public int NumberBadges
        {
            get { return numberBadges; }
            set { numberBadges = value; }
        }

        private List<Pokemon> pokemonList;

        public List<Pokemon> PokemonList
        {
            get { return pokemonList; }
            set { pokemonList = value; }
        }

    }
}
