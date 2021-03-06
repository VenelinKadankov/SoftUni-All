using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            HomeworkSubmissions = new HashSet<Homework>();
            CourseEnrollments = new HashSet<StudentCourse>();
        }

        [Key]
        public int StudentId { get; set; }

        [DataType("NVARCHAR(100)")]
        [Required]
        public string Name { get; set; }
        
        [DataType("char(10)")]
        public string PhoneNumber { get; set; }

       // [DataType("DATE")]
        public DateTime RegisteredOn { get; set; }

       // [DataType("DATE")]
        public DateTime? Birthday { get; set; }

        [InverseProperty(nameof(Homework.Student))]
        public ICollection<Homework> HomeworkSubmissions { get; set; }

        [InverseProperty(nameof(StudentCourse.Student))]
        public ICollection<StudentCourse> CourseEnrollments { get; set; }
    }
}
