using SchoolMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMVC.Repository
{
	public class IRepository
	{
		protected SchoolDbContext db;
		public IRepository()
		{
			db = new SchoolDbContext();
		}
		public IRepository(SchoolDbContext _db)
		{
			db = _db;
		}
		public async Task SaveChange()
		{
			await db.SaveChangesAsync();
		}
	}
}
