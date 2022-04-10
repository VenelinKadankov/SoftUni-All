using System;
using System.Reflection.Emit;

namespace Articles
{
    class Articles
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string title = input[0];
            string content = input[1];
            string author = input[2];
            int num = int.Parse(Console.ReadLine());

            Article article = new Article(title, content, author);

            for (int i = 0; i < num; i++)
            {
                string[] line = Console.ReadLine().Split(": ");
                string action = line[0];
                string command = line[1];

                switch (action)
                {
                    case "Edit":
                        article.Edit(command);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(command);
                        break;
                    case "Rename":
                        article.Rename(command);
                        break;
                    default:
                        break;
                }

            }

            Console.WriteLine(article.ToString());
        }
    }

    public class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        
        public void Edit(string content)
        {
            Content = content;
        }

        public void ChangeAuthor(string author)
        {
            Author = author;
        }

        public void Rename(string title)
        {
            Title = title;
        }

       // public void ToString()
      //  {
       //    Console.WriteLine($"{Title} - {Content}: {Author}");
        //}

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
}
