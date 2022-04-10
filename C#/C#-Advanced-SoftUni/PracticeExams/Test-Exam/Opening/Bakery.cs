using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            data = new List<Employee>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count 
        {
            get 
            {
                return data.Count;
            } 
        }

        public void Add(Employee employee)
        {
            if (data.Count < Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            int count = data.Count;
            data.Remove(data.FirstOrDefault(a => a.Name == name));

            return data.Count != count;
        }

        public Employee GetOldestEmployee()
        {
            int maxAge = int.MinValue;

            foreach (var employee in data)
            {
                if (employee.Age > maxAge)
                {
                    maxAge = employee.Age;
                }
            }

            return data.Find(a => a.Age == maxAge);
        }

        public Employee GetEmployee(string name)
        {
            return data.Find(a => a.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var employee in data)
            {
                sb.AppendLine($"{employee.ToString()}");
            }

            return sb.ToString();
        }
    }
}
