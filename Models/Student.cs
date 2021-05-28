using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolMVC.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? YearOfBirth { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public string Detail { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; }
    }
}
