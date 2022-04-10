using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRosterAgain
{
    class RosterAgain
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Employee> workers = CreateRoster(count);
            string highestDepartment = FindHighestDepartment(workers);
            PrintResult(workers, highestDepartment);
        }

        public static List<Employee> CreateRoster(int count)
        {
            List<Employee> workers = new List<Employee>(count);

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = tokens[0], department = tokens[2];
                double salary = double.Parse(tokens[1]);
                Employee currentWorker = new Employee(name, salary, department);
                workers.Add(currentWorker);
            }

            return workers;
        }

        public static string FindHighestDepartment(List<Employee> workers)
        {
            string departmentWithHighest = string.Empty;
            double highestAverage = 0.0;

            for (int i = 0; i < workers.Count; i++)
            {
                string currentDepartment = workers[i].Department;

                if (departmentWithHighest != currentDepartment)
                {

                    List<Employee> workersInDepartment = workers.Where(b => b.Department == currentDepartment).ToList();
                    double salaryTogether = workersInDepartment.Select(a => a.Salary).Aggregate((a, b) => a + b);
                    double average = salaryTogether / workersInDepartment.Count;

                    if (average > highestAverage)
                    {
                        highestAverage = average;
                        departmentWithHighest = currentDepartment;
                    }
                }
               
            }

            return departmentWithHighest;
        }

        static void PrintResult(List<Employee> workers, string highestDepartment)
        {
            List<Employee> wanted = workers.Where(b => b.Department == highestDepartment).ToList();
            //wanted.Sort((a, b) => (int)b.Salary - (int)a.Salary);
            wanted = wanted.OrderByDescending(x => x.Salary).ToList();
            //wanted.Reverse();


            Console.WriteLine($"Highest Average Salary: {highestDepartment}");
            wanted.ForEach(a => Console.WriteLine($"{a.Name} {a.Salary:F2}"));
        }

    }
    class Employee
    {
        public Employee(string name, double salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }

        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }
}
