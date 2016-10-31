using System;
using System.Collections.Generic;
using System.Linq;

namespace Raupjc_dz2_zad4
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender1 { get; set; }

        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(object obj)
        {
            var student = obj as Student;
            if ((bool)(student == null)) return false;
            return student.Jmbag.Equals(Jmbag);
        }

        public override int GetHashCode()
        {
            return Jmbag.GetHashCode();
        }

        public static object operator ==(Student a, Student b)
        {
            if (ReferenceEquals(a, null))
                return ReferenceEquals(b, null);

            return a.Equals(b);
        }

        public static object operator !=(Student a, Student b)
        {
            return !Equals(a, b);
        }


        public enum Gender
        {
            Male,
            Female
        }

        public static void Example1()
        {
            var list = new List<Student>()
            {
                new Student(" Ivan ", " 001234567 ")
            };
            var ivan = new Student(" Ivan ", " 001234567 ");
            // false :(
            bool anyIvanExists = list.Any(s => (bool) (s == ivan));
            Console.WriteLine(anyIvanExists);
        }

        private static void Example2()
        {
            var list = new List<Student>
            {
                new Student(" Ivan ", " 001234567 "),
                new Student(" Ivan ", " 001234567 ")
            };
            // 2 :(
            var distinctStudents = list.Distinct().Count();
            Console.WriteLine(distinctStudents);
        }


        public static void Main()
        {
            Example1();
            Example2();
        } 
    }
}
