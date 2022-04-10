using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDontGo
{
    class PokemonDontGo
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int finalSum = 0;

            int index = int.Parse(Console.ReadLine());

            while (pokemons.Count > 0)
            {
                int removed = 0;

                if (index < 0)
                {
                    removed = pokemons[0];
                    pokemons[0] = pokemons[pokemons.Count - 1];
                }
                else if (index >= pokemons.Count)
                {
                    removed = pokemons[pokemons.Count - 1];
                    pokemons[pokemons.Count - 1] = pokemons[0];
                }
                else
                {
                    removed = pokemons[index];
                    pokemons.RemoveAt(index);
                }

                for (int i = 0; i < pokemons.Count; i++)
                {
                    if (pokemons[i] <= removed)
                    {
                        pokemons[i] += removed;
                    }
                    else
                    {
                        pokemons[i] -= removed;
                    }
                }

                finalSum += removed;

                if(pokemons.Count == 0)
                {
                    break;
                }

                index = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(finalSum);
        }
    }
}
