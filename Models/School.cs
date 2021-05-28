using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolMVC.Models
{
    public partial class School
    {
        public School()
        {
            Classes = new HashSet<Class>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
