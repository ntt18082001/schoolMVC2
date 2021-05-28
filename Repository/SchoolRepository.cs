using Microsoft.EntityFrameworkCore;
using SchoolMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMVC.Repository
{
	public class SchoolRepository : IRepository
	{
		public SchoolRepository() : base() { }
		public SchoolRepository(SchoolDbContext _db) : base (_db) { }
		public async Task Add(School entity)
		{
			await db.AddAsync(entity);
		}

		public School FindById(int id)
		{
			return db.Schools.Find(id);
		}

		public List<School> GetAll()
		{
			return db.Schools
				.OrderByDescending(x => x.Id)
				.ToList();
		}

		public async Task Remove(int id)
		{
			School school = await db.Schools
				.Include(x => x.Classes)
				.ThenInclude(x => x.Students)
				.SingleOrDefaultAsync(x => x.Id == id);
			foreach(var item in school.Classes)
			{
				foreach(var item2 in item.Students)
				{
					db.Students.Remove(item2);
				}
				db.Classes.Remove(item);
			}
			db.Schools.Remove(school);
		}

		public async Task Update(School entity)
		{
			db.Schools.Update(entity);
		}
	}
}
