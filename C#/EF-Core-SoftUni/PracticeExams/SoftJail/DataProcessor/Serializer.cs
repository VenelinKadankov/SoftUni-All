namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var result = context.Prisoners.ToArray().Where(x => ids.Contains(x.Id))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(y => new
                    {
                        OfficerName = y.Officer.FullName,
                        Department = y.Officer.Department.Name
                    })
                    .OrderBy(y => y.OfficerName)
                    .ToList(),
                    TotalOfficerSalary = x.PrisonerOfficers.Sum(y => y.Officer.Salary) // ..ToString("f2") и после да се парсне към decimal
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            var jsonResult = JsonConvert.SerializeObject(result, Formatting.Indented);

            return jsonResult;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var serializer = new XmlSerializer(typeof(PrisonerMailsExportDto[]), new XmlRootAttribute("Prisoners"));

            var sb = new StringBuilder();
            var writer = new StringWriter(sb);

            var prisoners = context.Prisoners
                .ToArray()
                .Where(x => prisonersNames.Contains(x.FullName))
                .Select(x => new PrisonerMailsExportDto
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = x.Mails
                    .Select(y => new MessageExportDto
                    {
                        Description = string.Join("", y.Description.Reverse())
                    })
                    .ToArray()
                })
                .ToArray()
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            serializer.Serialize(writer, prisoners, ns);

            return sb.ToString().Trim();
        }
    }
}