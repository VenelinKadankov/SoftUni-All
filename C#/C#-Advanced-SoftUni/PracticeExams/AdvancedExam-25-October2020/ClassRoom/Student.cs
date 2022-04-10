using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomProject
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private string subject;

        public Student(string firstName, string lastName, string subject)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Subject = subject;
        }

        public string FirstName 
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                this.lastName = value;
            }
        }
        public string Subject
        {
            get
            {
                return this.subject;
            }
            private set
            {
                this.subject = value;
            }
        }

        public override string ToString()
        {
            return $"Student: First Name = {firstName}, Last Name = {lastName}, Subject = {subject}";
        }
    }
}
