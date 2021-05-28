using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMVC.Models
{
	public class ListSchool
	{
		public Class Class { get; set; }
		public ICollection<School> Schools { get; set; }
	}
}
