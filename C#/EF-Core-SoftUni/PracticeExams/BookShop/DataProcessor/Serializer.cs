namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var mostCraziestAuthors = context.Authors
                .Select(x => new
                {
                    AuthorName = x.FirstName + " " + x.LastName,
                    Books = x.AuthorsBooks
                    .OrderByDescending(y => y.Book.Price)
                    .Select(y => new
                    {
                        BookName = y.Book.Name,
                        BookPrice = y.Book.Price.ToString("f2")
                    })
                    .ToArray()
                })
                .ToArray()
                .OrderByDescending(x => x.Books.Length)
                .ThenBy(x => x.AuthorName)
                .ToArray();

            var result = JsonConvert.SerializeObject(mostCraziestAuthors, Formatting.Indented);

            return result;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var serializer = new XmlSerializer(typeof(BookExportDto[]), new XmlRootAttribute("Books"));

            var sb = new StringBuilder();
            var writer = new StringWriter(sb);

            var genre = Enum.Parse<Genre>("Science");

            var bookExport = context.Books
                .ToArray()
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => x.PublishedOn)
                .Where(x => x.PublishedOn < date && x.Genre == genre)
                .Select(x => new BookExportDto
                {
                    Pages = x.Pages,
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                })
                .Take(10)
                .ToArray();

            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            serializer.Serialize(writer, bookExport, ns);

            return sb.ToString().Trim();
        }
    }
}