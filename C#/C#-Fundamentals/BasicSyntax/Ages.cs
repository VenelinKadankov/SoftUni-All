using System;
using System.Runtime.InteropServices.ComTypes;

namespace Ages
{
    class Ages
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            string status = "";

            if (age <= 2)
            {
                status = "baby";
            } 
            else if (age <= 13)
            {
                status = "child";
            }
            else if (age <= 19)
            {
                status = "teenager";
            }
            else if (age <= 65)
            {
                status = "adult";
            }
            else
            {
                status = "elder";
            }

            Console.WriteLine($"{status}");
        }
    }
}
