using System;
using System.Text;

namespace HTML
{
    class HTML
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string content = Console.ReadLine();
            string command = Console.ReadLine();
            StringBuilder result = new StringBuilder();

            result.AppendLine("<h1>");
            result.AppendLine(title);
            result.AppendLine("</h1>");
            result.AppendLine("<article>");
            result.AppendLine(content);
            result.AppendLine("</article>");


            while (command != "end of comments")
            {
                result.AppendLine("<div>");
                result.AppendLine(command);
                result.AppendLine("</div>");

                command = Console.ReadLine();
            }

            Console.WriteLine(result.ToString());
        }
    }
}
