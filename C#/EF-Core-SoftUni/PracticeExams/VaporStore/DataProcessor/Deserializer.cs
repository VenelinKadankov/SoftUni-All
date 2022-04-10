namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var gamesDtos = JsonConvert.DeserializeObject<GameDevImportDto[]>(jsonString);

			var developers = new List<Developer>();
			var genres = new List<Genre>();
			var tags = new List<Tag>();
			var games = new List<Game>();

			var sb = new StringBuilder();

            foreach (var gameImport in gamesDtos)
            {
                if (!IsValid(gameImport) || !gameImport.Tags.All(IsValid))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var isValidDate = DateTime.TryParseExact(
					gameImport.ReleaseDate, "yyyy-MM-dd",
					CultureInfo.InvariantCulture, DateTimeStyles.None,
					out DateTime releaseDate);

                if (!isValidDate)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

                if (!developers.Any(x => x.Name == gameImport.Developer))
                {
					developers.Add(new Developer { Name = gameImport.Developer });
                }

				if (!genres.Any(x => x.Name == gameImport.Genre))
				{
					genres.Add(new Genre { Name = gameImport.Genre });
				}

				var currentTags = new List<GameTag>();

                foreach (var tag in gameImport.Tags)
                {
                    if (!tags.Any(x => x.Name == tag))
                    {
						tags.Add(new Tag { Name = tag });
                    }

					currentTags.Add(new GameTag { Tag = tags.FirstOrDefault(x => x.Name == tag) });
                }

				currentTags.ToArray();

				var game = new Game
				{
					Name = gameImport.Name,
					Price = gameImport.Price,
					ReleaseDate = releaseDate,
					Developer = developers.FirstOrDefault(x => x.Name == gameImport.Developer),
					Genre = genres.FirstOrDefault(x => x.Name == gameImport.Genre),
					GameTags = currentTags
				};

				games.Add(game);
				sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
			}

			context.Games.AddRange(games);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var usersImportDtos = JsonConvert.DeserializeObject<UserImportDto[]>(jsonString);

			var sb = new StringBuilder();
			var users = new List<User>();

            foreach (var userDto in usersImportDtos)
            {
                if (!IsValid(userDto) || !userDto.Cards.All(IsValid))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var user = new User
				{
					Username = userDto.Username,
					FullName = userDto.FullName,
					Email = userDto.Email,
					Age = userDto.Age,
					Cards = userDto.Cards.Select(x => new Card
					{
						Number = x.Number,
						Cvc = x.CVC,
						Type = Enum.Parse<CardType>(x.Type)
					}).ToList()
				};

				users.Add(user);
				sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards"!);
            }

			context.Users.AddRange(users);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var serializer = new XmlSerializer(typeof(PurchaseImportDto[]), new XmlRootAttribute("Purchases"));

			var sb = new StringBuilder();

			var reader = new StringReader(xmlString);

			var purchaseImportDtos = serializer.Deserialize(reader) as PurchaseImportDto[];

			var purchases = new List<Purchase>();
			var games = context.Games.ToArray();

            foreach (var purDto in purchaseImportDtos)
            {
                if (!IsValid(purDto))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var isValidDate = DateTime.TryParseExact(
					purDto.Date, "dd/MM/yyyy HH:mm",
					CultureInfo.InvariantCulture, DateTimeStyles.None,
					out DateTime date);

                if (!isValidDate)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				var purchase = new Purchase
				{
					Type = Enum.Parse<PurchaseType>(purDto.Type),
					ProductKey = purDto.Key,
					Game = games.FirstOrDefault(x => x.Name == purDto.Title),
					Card = context.Cards.FirstOrDefault(x => x.Number == purDto.Card),
					Date = date
				};

				purchases.Add(purchase);

				var user = context.Users.FirstOrDefault(x => x.Cards.Any(y => y.Number == purDto.Card));

				sb.AppendLine($"Imported {purchase.Game.Name} for {user.Username}");
            }

			context.Purchases.AddRange(purchases);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}