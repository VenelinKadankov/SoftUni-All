using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDontGo
{
    class PokemonDontGo
    {
        static void Main(string[] args)
        {
            List<long> pokemons = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();
            long finalSum = 0;

            int index = int.Parse(Console.ReadLine());

            while (pokemons.Count > 0)
            {

                if(pokemons.Sum() == 0)
                {
                    break;
                }

                if (pokemons.Count == 1 && (index >= pokemons.Count || index < 0))
                {
                    long value = pokemons[0];
                    pokemons.RemoveAt(0);
                    finalSum += value;
                }
                else if (index >= pokemons.Count)
                {
                    long num = pokemons[0], removed = pokemons[pokemons.Count - 1];
                    pokemons.RemoveAt(pokemons.Count - 1);
                    pokemons.Add(num);

                    IncreaseDecreaseElements(pokemons, removed);

                    finalSum += removed;
                }
                else if (index < 0)
                {
                    long num = pokemons[pokemons.Count - 1], removed = pokemons[0];
                    pokemons.RemoveAt(0);
                    pokemons.Insert(0, num);

                    IncreaseDecreaseElements(pokemons, removed);

                    finalSum += removed;
                }
                else
                {
                    long value = pokemons[index];
                    pokemons.Remove(value);

                    IncreaseDecreaseElements(pokemons, value);

                    finalSum += value;
                }

                if (pokemons.Count == 0)
                {
                    break;
                }

                index = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(finalSum);
        }

        private static void IncreaseDecreaseElements(List<long> pokemons, long removed)
        {
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
        }
    }
}
