namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var deptCellsDtos = JsonConvert.DeserializeObject<DepartmentCellsImportDto[]>(jsonString);

            var departments = new List<Department>();
            var sb = new StringBuilder();

            foreach (var deptDto in deptCellsDtos)
            {
                if (!IsValid(deptDto) || !deptDto.Cells.All(IsValid) || deptDto.Cells.Count == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var department = new Department
                {
                    Name = deptDto.Name,
                    Cells = deptDto.Cells.Select(x => new Cell
                    {
                        CellNumber = x.CellNumber,
                        HasWindow = x.HasWindow
                    }).ToList()
                };

                departments.Add(department);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonerMailsDtos = JsonConvert.DeserializeObject<PrisonerMailsImportDto[]>(jsonString);

            var sb = new StringBuilder();
            var prisoners = new List<Prisoner>();

            foreach (var prisMailDt in prisonerMailsDtos)
            {
                if (!IsValid(prisMailDt) || !prisMailDt.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var isValidIncarDate = DateTime.TryParseExact(
                    prisMailDt.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime incarceration);

                var isValidRelease = DateTime.TryParseExact(
                    prisMailDt.ReleaseDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime release);

                if (!isValidIncarDate)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var prisoner = new Prisoner
                {
                    FullName = prisMailDt.FullName,
                    Nickname = prisMailDt.Nickname,
                    Age = prisMailDt.Age,
                    IncarcerationDate = incarceration,
                    ReleaseDate = release,
                    Bail = prisMailDt.Bail,
                    CellId = prisMailDt.CellId,
                    Mails = prisMailDt.Mails.Select(x => new Mail
                    {
                        Description = x.Description,
                        Sender = x.Sender,
                        Address = x.Address
                    }).ToArray()
                };

                prisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(OfficerPRisonerImportDto[]), new XmlRootAttribute("Officers"));

            var reader = new StringReader(xmlString);
            var sb = new StringBuilder();
            var officers = new List<Officer>();

            var officersPrisonersDtos = serializer.Deserialize(reader) as OfficerPRisonerImportDto[];

            foreach (var oPd in officersPrisonersDtos)
            {
                if (!IsValid(oPd) || !oPd.Prisoners.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var offpris = new List<OfficerPrisoner>();

                foreach (var item in oPd.Prisoners)
                {
                    var pris = context.OfficersPrisoners.FirstOrDefault(x => x.PrisonerId == item.Id);

                    if (pris == null)
                    {
                        pris = new OfficerPrisoner
                        {
                            PrisonerId = item.Id
                        };
                    }

                    offpris.Add(pris);
                }

                var officer = new Officer
                {
                    FullName = oPd.Name,
                    Salary = oPd.Money,
                    Position = Enum.Parse<Position>(oPd.Position),
                    Weapon = Enum.Parse<Weapon>(oPd.Weapon),
                    DepartmentId = oPd.DepartmentId,
                    OfficerPrisoners = offpris
                };

                officers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}