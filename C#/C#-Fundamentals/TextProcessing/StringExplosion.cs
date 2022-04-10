using System;
using System.Collections.Generic;

namespace StringExplosion
{
    class StringExplosion
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char symbol = '>';
            int startIndex = 0;
            int powerToAdd = 0;

            while (text.IndexOf(symbol, startIndex) > -1)
            {
                startIndex = text.IndexOf(symbol, startIndex) + 1;
                int power = (int)Char.GetNumericValue(text[startIndex]);
                power += powerToAdd;
                //powerToAdd 

                string textLeft = text.Substring(startIndex);

                if (power > textLeft.Length)
                {
                    power = textLeft.Length;
                }

                while(power > 0)
                {
                    power--;

                    if (text[startIndex] != '>')
                    {
                        text = text.Remove(startIndex, 1);
                        //powerToAdd--;

                        if (powerToAdd > 0)
                        {
                            powerToAdd--;
                        }
                    }
                    else
                    {
                        powerToAdd++;
                        break;
                    }

                   // power--;
                }

            }

            Console.WriteLine(string.Join("--", text));
        }
    }
}
