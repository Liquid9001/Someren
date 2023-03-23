using System;

namespace SomerenModel
{
    public class Student
    {
        public int Id { get; set; }     // database id
        public string FName { get; set; }
        public string LName { get; set; }
        public int Number { get; set; } // StudentNumber, e.g. 474791
        public DateTime BirthDate { get; set; }

        public string FullName { get { return $"{FName} {LName}";} }
    }
}