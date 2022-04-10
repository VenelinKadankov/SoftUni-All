using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Students
{
    class Students
    {
        static void Main(string[] args)
        {
            int countStudents = int.Parse(Console.ReadLine());
            List<Student> allStudents = new List<Student>(countStudents);

            for (int i = 0; i < countStudents; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                double grade = double.Parse(tokens[2]);
                Student current = new Student(tokens[0], tokens[1], grade);
                allStudents.Add(current);
            }

            //allStudents.Sort((a, b) => (int)b.Grade - (int)a.Grade);
            allStudents.Sort((a, b) => a.Grade.CompareTo(b.Grade));
            allStudents.Reverse();

            foreach (var item in allStudents)
            {
                Console.WriteLine(item.ToString()); 
            }
        }
    }

    class Student
    {
        public Student(string firstName, string secondName, double grade)
        {
            FirstName = firstName;
            SecondName = secondName;
            Grade = grade;
        }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {SecondName}: {Grade:f2}";
        }
    }
}
