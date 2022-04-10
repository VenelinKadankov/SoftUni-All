using System;
using System.Collections.Generic;

namespace CrossRoads
{
    class CrossRoads
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeZone = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            string hitCar = string.Empty;
            bool isHit = false;
            char atLetter = 'a';
            int counter = 0;

            while (command?.ToUpper() != "END")
            {
                Queue<char> queue = new Queue<char>();

                if (command?.ToLower() == "green")
                {
                    string car;

                    if (cars.TryDequeue(out car))
                    {
                        counter++;
                        hitCar = car;

                        foreach (char item in car)
                        {
                            queue.Enqueue(item);
                        }

                    }
                    else
                    {
                        command = Console.ReadLine();
                        continue;
                    }


                    for (int i = 0; i < greenLight + freeZone; i++)
                    {
                        if (i < greenLight)
                        {
                            char character;

                            if (queue.TryDequeue(out character))
                            {
                            }
                            else
                            {
                                string nextCar;

                                if (cars.TryDequeue(out nextCar))
                                {
                                    hitCar = nextCar;
                                    counter++;

                                    foreach (char item in nextCar)
                                    {
                                        queue.Enqueue(item);
                                    }

                                    queue.Dequeue();
                                }

                            }

                        }
                        else
                        {
                            char character;
                            queue.TryDequeue(out character);
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }

                if (queue.Count > 0)
                {
                    atLetter = queue.Dequeue();
                    isHit = true;
                    break;
                }

                command = Console.ReadLine();
            }

            if (isHit)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{hitCar} was hit at {atLetter}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{counter} total cars passed the crossroads.");
            }
        }
    }
}
