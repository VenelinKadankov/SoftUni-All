using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private IList<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get; set; }

        public int Count
        {
            get => this.students.Count;
        }

        public string RegisterStudent(Student student)
        {
            if (this.Count >= this.Capacity)
            {
                return "No seats in the classroom";
            }
            else
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            //Student dissmissedStudent = this.students.FirstOrDefault(s => s.FirstName.Equals(firstName) && s.LastName.Equals(lastName));

            if (this.students.Any(s => s.FirstName.Equals(firstName) && s.LastName.Equals(lastName)))
            {
                Student dissmissedStudent = this.students.FirstOrDefault(s => s.FirstName.Equals(firstName) && s.LastName.Equals(lastName));
                students.Remove(dissmissedStudent);
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();

            if (students.Any(s => s.Subject.Equals(subject)))
            {
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                int counter = 0;

                foreach (Student student in this.students)
                {
                    if (student.Subject.Equals(subject))
                    {
                        sb.Append($"{student.FirstName} {student.LastName}");
                    }

                    counter++;

                    if (students.Skip(counter).Any(s => s.Subject.Equals(subject)))
                    {
                        sb.AppendLine();
                    }
                }

                return sb.ToString();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return this.students.Count;
        }

        public Student GetStudent(string firstName, string lastName) 
        {
            Student student = this.students.FirstOrDefault(s => s.FirstName.Equals(firstName) && s.LastName.Equals(lastName));

            return student;
        }
    }
}
