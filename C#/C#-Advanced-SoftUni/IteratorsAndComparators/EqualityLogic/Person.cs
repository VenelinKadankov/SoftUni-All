using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        private string name;

        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public int CompareTo(Person other)
        {
            int result = this.name.CompareTo(other.name);

            if (result == 0)
            {
                result = this.age.CompareTo(other.age);
            }

            return result;
        }


        //public override bool Equals(object obj)
        //{
        //    if (obj != null && obj is Person otherPerson)
        //    {
        //        if (this.CompareTo(otherPerson) == 0)
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        public override bool Equals(object other)
        {
            if (other != null && other is Person otherPerson)
            {
                return name == otherPerson.name && age == otherPerson.age;
            }
            return false;
                   
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode() + this.age.GetHashCode();
        }
    }
}
