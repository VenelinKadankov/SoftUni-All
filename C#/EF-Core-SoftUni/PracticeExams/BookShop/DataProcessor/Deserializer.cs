namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(BookImportDto[]), new XmlRootAttribute("Books"));

            var sb = new StringBuilder();
            var reader = new StringReader(xmlString);
            var books = new List<Book>();

            var booksDtos = serializer.Deserialize(reader) as BookImportDto[];

            foreach (var dto in booksDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var isValidDate = DateTime.TryParseExact(
                    dto.PublishedOn, "MM/dd/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime publishedOn);

                if (!isValidDate)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var book = new Book
                {
                    Name = dto.Name,
                    Genre = (Genre)dto.Genre,
                    Price = dto.Price,
                    Pages = dto.Pages,
                    PublishedOn = publishedOn
                };

                books.Add(book);
                sb.AppendLine($"Successfully imported book {book.Name} for {book.Price:f2}.");
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorsDtos = JsonConvert.DeserializeObject<AuthorImportDto[]>(jsonString);

            var sb = new StringBuilder();
            var authors = new List<Author>();
            var authorMails = new List<string>();

            foreach (var dto in authorsDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var authorBooks = new List<Book>();

                foreach (var bookId in dto.Books)
                {
                    var book = context.Books.FirstOrDefault(x => x.Id == bookId.Id);

                    if (book == null)
                    {
                        continue;
                    }

                    authorBooks.Add(book);
                }

                if (authorBooks.Count == 0)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                if (authorMails.Contains(dto.Email))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }
                authorMails.Add(dto.Email);

                var author = new Author
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Phone = dto.Phone,
                    Email = dto.Email,
                    AuthorsBooks = authorBooks.Select(x => new AuthorBook { BookId = x.Id }).ToArray()
                };

                authors.Add(author);
                sb.AppendLine($"Successfully imported author - {author.FirstName} {author.LastName} with {author.AuthorsBooks.Count} books.");
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}