namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var serializer = new XmlSerializer(typeof(ProjectTasksExportDto[]), new XmlRootAttribute("Projects"));

            var sb = new StringBuilder();
            var writer = new StringWriter(sb);
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var projectsExport = context.Projects
                .ToArray()
                .Where(x => x.Tasks.Count > 0)
                .Select(x => new ProjectTasksExportDto
                {
                    TasksCount = x.Tasks.Count.ToString(),
                    ProjectName = x.Name,
                    HasEndDate = x.DueDate == null ? "No" : "Yes",
                    Tasks = x.Tasks.Select(t => new TaskInProjectExport
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .ToArray()
                .OrderByDescending(x => x.Tasks.Length)
                .ThenBy(x => x.ProjectName)
                .ToArray();

            serializer.Serialize(writer, projectsExport, ns);

            return sb.ToString().Trim();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var mostBusiestEmployees = context.Employees
                .ToArray() // провери дали с това или без
                .Select(x => new
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks
                    .Where(y => y.Task.OpenDate >= date)
                    .OrderByDescending(y => y.Task.DueDate)
                    .ThenBy(y => y.Task.Name)
                    .Select(t => new
                    {
                        TaskName = t.Task.Name,
                        OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = t.Task.LabelType.ToString(),
                        ExecutionType = t.Task.ExecutionType.ToString()
                    }).ToArray()
                })
                .ToArray()
                .Where(x => x.Tasks.Length > 0)
                .OrderByDescending(x => x.Tasks.Length)
                .ThenBy(x => x.Username)
                .Take(10)
                .ToArray();

            var result = JsonConvert.SerializeObject(mostBusiestEmployees, Formatting.Indented);

            return result;
        }
    }
}