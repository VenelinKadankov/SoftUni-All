namespace TeisterMask.DataProcessor
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
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ProjectImportDto[]), new XmlRootAttribute("Projects"));

            var sb = new StringBuilder();
            var reader = new StringReader(xmlString);

            var projects = new List<Project>();

            var projectsTasksDto = serializer.Deserialize(reader) as ProjectImportDto[];

            foreach (var dto in projectsTasksDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidProjectOpenDate = DateTime.TryParseExact(
                    dto.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime projectOpening);

                var isValidProjectClosing = DateTime.TryParseExact(
                    dto.DueDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime projectClosing);

                if (!isValidProjectOpenDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var currentProjectTasks = new List<Task>();

                foreach (var taskDto in dto.Tasks)
                {

                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var isValidTaskOpening = DateTime.TryParseExact(
                    taskDto.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime taskOpening);

                    var isValidTaskClosing = DateTime.TryParseExact(
                    taskDto.DueDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime taskClosing);

                    if (!isValidTaskOpening || !isValidTaskClosing)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpening < projectOpening || (isValidProjectClosing && taskClosing > projectClosing))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    currentProjectTasks.Add(new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpening,
                        DueDate = taskClosing, // може да е null и ще гръмне
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType
                    });
                }

                var project = new Project
                {
                    Name = dto.Name,
                    OpenDate = projectOpening,
                    DueDate = projectClosing,
                    Tasks = currentProjectTasks
                };

                projects.Add(project);
                sb.AppendLine($"Successfully imported project - {project.Name} with {project.Tasks.Count} tasks.");
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeesDto = JsonConvert.DeserializeObject<EmployeeImportDto[]>(jsonString);

            var sb = new StringBuilder();

            var employees = new List<Employee>();

            var tasks = context.Tasks.ToArray();

            foreach (var dto in employeesDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var currentEmployeeTasks = new HashSet<Task>();

                foreach (var task in dto.Tasks)
                {
                    if (!tasks.Select(x => x.Id).Contains(task))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    currentEmployeeTasks.Add(tasks.FirstOrDefault(x => x.Id == task));
                }

                var employee = new Employee
                {
                    Username = dto.Username,
                    Email = dto.Email,
                    Phone = dto.Phone,
                    EmployeesTasks = currentEmployeeTasks.Select(x => new EmployeeTask { Task = x }).ToArray()
                };

                employees.Add(employee);
                sb.AppendLine($"Successfully imported employee - {employee.Username} with {employee.EmployeesTasks.Count} tasks.");
            }

            context.Employees.AddRange(employees);
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