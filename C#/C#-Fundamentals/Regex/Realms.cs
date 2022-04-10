using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AgainNetherRealm
{
    class Realms
    {
        static void Main(string[] args)
        {
            string splitPattern = @"\s+|,+\s*";
            string[] Names = Regex.Split(Console.ReadLine(), splitPattern);
            //string[] names = Console.ReadLine().Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries).OrderBy(d => d).ToArray();
            List<Player> players = new List<Player>(Names.Length);
            List<string> names = Names.Where(a => a != "").ToList();

            foreach (var item in names)
            {
                string name = item;
                int health = GetHealth(name);
                double damage = GetDamage(name);

                Player current = new Player(name, health, damage);
                players.Add(current);
            }

            var output = players.OrderBy(a => a.Name).ToList();

            foreach (var item in output)
            {
                Console.WriteLine($"{item.Name} - {item.Health} health, {item.Damage:F2} damage");
            }

        }

        public static int GetHealth(string text)
        {
            int sum = 0;
            string pattern = @"[^\+\-\*\/\.\d\s\,]";
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(text))
            {


                MatchCollection chars = regex.Matches(text);

                foreach (Match match in chars)
                {
                    //char character = Convert.ToChar(match.Value);
                    //int num = Convert.ToInt32(character);
                    foreach (char item in match.Value)
                    {
                        sum += (int)item;
                    }

                }

            }

            return sum;
        }

        public static double GetDamage(string text)
        {
            double sum = 0;
            string pattern = @"[\-\+]?[\d]+(?:[\.]*[\d]+|[\d]*)";
            string specialSigns = @"[\*\/]";
            Regex regex = new Regex(pattern);
            Regex special = new Regex(specialSigns);
            MatchCollection chars = regex.Matches(text);
            MatchCollection signs = special.Matches(text);

            foreach (Match match in chars)
            {
                double num = double.Parse(match.Value);
                sum += num;
            }

            foreach (Match item in signs)
            {
                if (item.Value == "/")
                {
                    sum /= 2;
                }
                else
                {
                    sum *= 2;
                }
            }

            return sum;

        }

        class Player
        {
            public Player(string text, int health, double damage)
            {
                Name = text;
                Health = health;
                Damage = damage;
            }

            public string Name { get; set; }
            public int Health { get; set; }
            public double Damage { get; set; }
        }
    }
}
