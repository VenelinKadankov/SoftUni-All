using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace CompanyRoster
{
    class CompanyRoster
    {
        static void Main(string[] args)
        {
            int countEmployees = int.Parse(Console.ReadLine());
            List<List<Employee>> employees = CreateRoster(countEmployees);
            CalculateAndPrint(employees);
        }

        public static List<List<Employee>> CreateRoster(int count)
        {
            List<List<Employee>> employees = new List<List<Employee>>();

            for (int i = 0; i < count; i++)
            {
                string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = line[0], department = line[2];
                double salary = double.Parse(line[1]);
                Employee worker = new Employee(name, salary, department);
                bool isAdded = false;

                if (employees.Count == 0)
                {
                    List<Employee> current = new List<Employee> { worker };
                    employees.Add(current);
                }
                else
                {
                    for (int j = 0; j < employees.Count; j++)
                    {

                        if (worker.Department == employees[j][0].Department)
                        {
                            employees[j].Add(worker);
                            isAdded = true;
                            break;
                        }

                    }

                    if (!isAdded)
                    {
                        List<Employee> current = new List<Employee> { worker };
                        employees.Add(current);
                    }

                }

            }

            return employees;
        }

        static void CalculateAndPrint(List<List<Employee>> employees)
        {
            double highestAverage = double.MinValue;
            string highestDepartment = string.Empty;

            for (int i = 0; i < employees.Count; i++)
            {
                List<Employee> currentDepartment = employees[i];
                double currentAverage = 0;

                for (int j = 0; j < currentDepartment.Count; j++)
                {
                    currentAverage += currentDepartment[j].Salary;
                }

                currentAverage /= currentDepartment.Count;

                if (currentAverage > highestAverage)
                {
                    highestAverage = currentAverage;
                    highestDepartment = currentDepartment[0].Department;
                }

            }

            Console.WriteLine($"Highest Average Salary: {highestDepartment}");
            List<Employee> wanted = new List<Employee>();

            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i][0].Department == highestDepartment)
                {
                    wanted = employees[i];
                }
            }

            wanted.Sort((a, b) => a.Salary != b.Salary ? (int)b.Salary - (int)a.Salary : a.Name.CompareTo(b.Name));
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
