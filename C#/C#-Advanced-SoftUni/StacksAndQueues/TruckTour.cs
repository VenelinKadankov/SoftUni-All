using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class TruckTour
    {
        static void Main(string[] args)
        {
            int pumps = int.Parse(Console.ReadLine());
            int tank = 0;
            int totalDistance = 0;
            Queue<int> stations = new Queue<int>(pumps);
            Queue<int> km = new Queue<int>(pumps);
            int index = int.MaxValue;
            int counter = 1;
            bool isFound = false;

            for (int i = 0; i < pumps; i++)
            {
                int[] arr = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

                stations.Enqueue(arr[0]);
                km.Enqueue(arr[1]);
               // tank += arr[0];
               // totalDistance += arr[1];

            }

            for (int i = 0; i < pumps; i++)
            {
                bool isContinued = false;
                int dist = km.Peek();
                int fuel = stations.Peek();
                int originalDist = km.Peek();
                int originalFuel = stations.Peek();

                for (int j = 0; j < pumps; j++)
                {
                    
                    dist = km.Dequeue();
                    fuel = stations.Dequeue();
                    km.Enqueue(dist);
                    stations.Enqueue(fuel);
                    tank += fuel;

                    if (tank < dist)
                    {
                        isContinued = true;
                        continue;
                    }

                    if (j == pumps - 1 && tank >= dist && !isContinued)
                    {
                        isFound = true;
                        index = i;
                    }
                    else if (tank >= dist && !isContinued)
                    {
                        tank -= dist;
                    }

                }

                if (isFound)
                {
                    break;
                }

                km.Dequeue();
                stations.Dequeue();
                km.Enqueue(originalDist);
                stations.Enqueue(originalFuel);
                tank = 0;
            }
            Console.WriteLine(index);
        }
    }
}
