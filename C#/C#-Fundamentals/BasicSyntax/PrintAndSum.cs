using System;

namespace PrintAndSum
{
    class PrintAndSum
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            string resultLine = "";
            int sum = 0;

            for(int i = start; i <= end; i++)
            {
                resultLine = resultLine + i + " ";
                sum += i;
            }

            Console.WriteLine(resultLine);
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
