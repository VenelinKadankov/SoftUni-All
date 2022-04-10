using BookShop.Models.Enums;
using BookShop.Data;
using BookShop.Initializer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BookShop
{
    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //var command = Console.ReadLine();

            //var result2 = GetBooksByAgeRestriction(db, command);
            //var result3 = GetGoldenBooks(db);
            //var result4 = GetBooksByPrice(db);
            //var result5 = GetBooksNotReleasedIn(db, 2000);
            //var result6 = GetBooksByCategory(db, "horror mystery drama");
            //var result7 = GetBooksReleasedBefore(db, "12-04-1992");
            //var result8 = GetAuthorNamesEndingIn(db, "dy");
            //var result9 = GetBookTitlesContaining(db, "WOR");
            //var result10 = GetBooksByAuthor(db, "po");
            //var result11 = CountBooks(db, 40);
            //var result12 = CountCopiesByAuthor(db);
            //var result13 = GetTotalProfitByCategory(db);
            //var result14 = GetMostRecentBooks(db);
            var result = RemoveBooks(db);

            Console.WriteLine(result);
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var removed = context.Books.Where(x => x.Copies < 4200).ToList();
            var count = removed.Count;


            foreach (var book in removed)
            {
               // context.Books.Remove(book);
            }

            context.SaveChanges();

            return count;
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(x => x.ReleaseDate.HasValue && x.ReleaseDate.Value.Year < 2010).ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categBooks = context.Categories
                .Select(x => new
                {
                    x.Name,
                    TopThree = x.CategoryBooks.Select(b => new 
                    {
                        b.Book.Title,
                        b.Book.ReleaseDate
                    })
                    .Where(b => b.ReleaseDate.HasValue)
                    .OrderByDescending(y => y.ReleaseDate)
                    .Take(3)
                })
                .OrderBy(x => x.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var item in categBooks)
            {
                sb.AppendLine($"--{item.Name}");

                foreach (var book in item.TopThree)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var profits = context.Categories
                .Select(x => new
                {
                    x.Name,
                    TotalMoney = x.CategoryBooks.Sum(b => b.Book.Copies * b.Book.Price)
                })
                .OrderByDescending(x => x.TotalMoney)
                .ToList();

            var result = string.Join(Environment.NewLine, profits.Select(x => $"{x.Name} ${x.TotalMoney:F2}"));

            return result;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var bookCopies = context.Authors
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    BookCopies = x.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(x => x.BookCopies)
                .ToList();

            var sb = new StringBuilder();

            foreach (var item in bookCopies)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} - {item.BookCopies}");
            }

            var result = sb.ToString();

            return result;
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();

            return books;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var text = input.ToLower();

            var books = context.Books
                .Select(x => new
                {
                    x.Title,
                    x.Author.FirstName,
                    x.Author.LastName,
                    x.BookId
                })
                .Where(x => x.LastName.ToLower().StartsWith(text))
                .OrderBy(x => x.BookId)
                .Select(x => x.Title + " (" + x.FirstName + " " + x.LastName + ")")
                .ToArray();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var text = input.ToLower();

            var books = context.Books
                .Select(x => x.Title)
                .Where(x => x.ToLower().Contains(text))
                .OrderBy(x => x)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => new { FullName = x.FirstName + " " + x.LastName })
                .OrderBy(x => x.FullName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine(author.FullName);
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

           // Console.WriteLine(dateTime);

            var books = context.Books
                .Where(x => x.ReleaseDate.HasValue && x.ReleaseDate < dateTime)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price,
                    x.ReleaseDate
                })

                .OrderByDescending(x => x.ReleaseDate)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            var result = sb.ToString();

            return result;
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower()).ToArray();

            var books = context.Books
                  .Include(x => x.BookCategories)
                  .ThenInclude(x => x.Category)
                  .ToList()
                  .Where(x => x.BookCategories.Any(cat => categories.Contains(cat.Category.Name.ToLower())))
                  .Select(x => x.Title)
                  .OrderBy(x => x)
                  .ToList();

            var result = string.Join(Environment.NewLine, books);


            return result;
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {

            var books = context.Books
                .Where(x => x.ReleaseDate.HasValue && x.ReleaseDate.Value.Year != year)
                .Select(x => new
                {
                    x.Title,
                    x.BookId
                })
                .OrderBy(x => x.BookId)
                .ToList();


            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            var result = sb.ToString();

            return result;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            var result = sb.ToString();

            return result;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var bookEdition = Enum.Parse<EditionType>("Gold", true);

            var books = context.Books
                .Where(x => x.Copies < 5000 && x.EditionType == bookEdition)
                .Select(x => x.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(x => x.AgeRestriction == ageRestriction)
                .Select(x => new
                {
                    x.Title
                })
                .OrderBy(y => y.Title)
                .ToList();



            //var books = context.Books.FromSqlInterpolated($"SELECT * FROM Books WHERE ");

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
