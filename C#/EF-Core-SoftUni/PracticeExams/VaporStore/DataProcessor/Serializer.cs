namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var games = context.Genres
				.Where(x => genreNames.Contains(x.Name))
				.ToArray()
				.Select(x => new
				{
					Id = x.Id,
					Genre = x.Name,
					Games = x.Games.Select(y => new
					{
						Id = y.Id,
						Title = y.Name,
						Developer = y.Developer.Name,
						Tags = string.Join(", ", y.GameTags.Select(gt => gt.Tag.Name)),
						Players = y.Purchases.Count
					})
					.Where(y => y.Players > 0)
					.OrderByDescending(y => y.Players)
					.ThenBy(y => y.Id)
					.ToArray(),
					TotalPlayers = x.Games.SelectMany(y => y.Purchases).Count()
				})
				.ToList()
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToArray();

            var result = JsonConvert.SerializeObject(games, Formatting.Indented);

			return result;

		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			var serializer = new XmlSerializer(typeof(UserPurchaseTypeExportDto[]), new XmlRootAttribute("Users"));

			var sb = new StringBuilder();
			var writer = new StringWriter(sb);

			var enumType = (PurchaseType)Enum.Parse(typeof(PurchaseType), storeType, true);

            var purchasesView = context.Users.ToList()
                .Select(x => new UserPurchaseTypeExportDto
                {
                    Username = x.Username,
                    Purchases = x.Cards
                    .SelectMany(y => y.Purchases)
					.Where(y => y.Type == enumType)
					.OrderBy(y => y.Date)
					.Select(y => new PurchaseDto
                    {
                        Card = y.Card.Number,
                        Cvc = y.Card.Cvc,
                        Date = y.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new GameDto
                        {
                            Title = y.Game.Name,
                            Genre = y.Game.Genre.Name,
                            Price = y.Game.Price
                        }
                    })
                    .ToArray(),
                    TotalSpent = x.Cards.SelectMany(y => y.Purchases).Where(y => y.Type == enumType).Sum(y => y.Game.Price)
				})
				.ToList()
				.Where(x => x.Purchases.Length > 0)
				.OrderByDescending(x => x.TotalSpent)
				.ThenBy(x => x.Username)
                .ToArray();



            var ns = new XmlSerializerNamespaces();
			ns.Add(string.Empty, string.Empty);

			serializer.Serialize(writer, purchasesView, ns);

			return sb.ToString().TrimEnd();
		}
	}
}