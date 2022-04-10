using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<Articles> output = new List<Articles>();


            for (int i = 0; i < num; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ");
                Articles current = new Articles(tokens[0], tokens[1], tokens[2]);

                output.Add(current);
            }

            string sorter = Console.ReadLine();

            switch (sorter)
            {
                case "title":
                    output.Sort((a, b) => a.Title.CompareTo(b.Title));
                    break;
                case "content":
                    output.Sort((a, b) => a.Content.CompareTo(b.Content));
                    break;
                case "author":
                    output.Sort((a, b) => a.Author.CompareTo(b.Author));
                    break;
                default:
                    break;
            }

            foreach (var item in output)
            {
                Console.WriteLine(item.ToString());
            }
            
            
        }
    }

    class Articles
    {
        public Articles(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author} ";
        }
    }
}
