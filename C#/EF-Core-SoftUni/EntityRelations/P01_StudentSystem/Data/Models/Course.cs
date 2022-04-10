using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            Resources = new HashSet<Resource>();
            HomeworkSubmissions = new HashSet<Homework>();
            StudentsEnrolled = new HashSet<StudentCourse>();
        }

        [Key]
        public int CourseId { get; set; }

        [MaxLength(80)]
        [DataType("NVARCHAR")]
       // [Required]
        public string Name { get; set; }

        [DataType("NVARCHAR")]
        public string Description { get; set; }

       // [DataType("DATE")]
        public DateTime StartDate { get; set; }

       // [DataType("DATE")]
        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        [InverseProperty(nameof(Resource.Course))]
        public ICollection<Resource> Resources { get; set; }

        [InverseProperty(nameof(Homework.Course))]
        public ICollection<Homework> HomeworkSubmissions { get; set; }

        [InverseProperty(nameof(StudentCourse.Course))]
        public ICollection<StudentCourse> StudentsEnrolled { get; set; }
    }
}
