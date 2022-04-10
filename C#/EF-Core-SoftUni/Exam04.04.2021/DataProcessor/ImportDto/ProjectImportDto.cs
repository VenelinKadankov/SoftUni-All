using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ProjectImportDto
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public TaskImportDto[] Tasks { get; set; }
    }

    //•	Id - integer, Primary Key
    //•	Name - text with length [2, 40] (required)
    //•	OpenDate - date and time(required)
    //•	DueDate - date and time(can be null)
    //•	Tasks - collection of type Task

    [XmlType("Task")]
    public class TaskImportDto
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [Required]
        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [Required]
        [EnumDataType(typeof(ExecutionType))]
        [XmlElement("ExecutionType")]
        public int ExecutionType { get; set; } // string

        [Required]
        [EnumDataType(typeof(LabelType))]
        [XmlElement("LabelType")]
        public int LabelType { get; set; } //string
    }
}

//•	Id - integer, Primary Key
//•	Name - text with length [2, 40] (required)
//•	OpenDate - date and time(required)
//•	DueDate - date and time(required)
//•	ExecutionType - enumeration of type ExecutionType, with possible values (ProductBacklog, SprintBacklog, InProgress, Finished) (required)
//•	LabelType - enumeration of type LabelType, with possible values (Priority, CSharpAdvanced, JavaAdvanced, EntityFramework, Hibernate) (required)
//•	ProjectId - integer, foreign key(required)
//•	Project - Project
//•	EmployeesTasks - collection of type EmployeeTask

/*  <Project>
    <Name>S</Name>
    <OpenDate>25/01/2018</OpenDate>
    <DueDate>16/08/2019</DueDate>
    <Tasks>
      <Task>
        <Name>Australian</Name>
        <OpenDate>19/08/2018</OpenDate>
        <DueDate>13/07/2019</DueDate>
        <ExecutionType>2</ExecutionType>
        <LabelType>0</LabelType>
      </Task>
      <Task>
        <Name>Upland Boneset</Name>
        <OpenDate>24/10/2018</OpenDate>
        <DueDate>11/06/2019</DueDate>
        <ExecutionType>2</ExecutionType>
        <LabelType>3</LabelType>
      </Task>
    </Tasks>
  </Project>
*/