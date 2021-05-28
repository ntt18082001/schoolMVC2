using Microsoft.EntityFrameworkCore;
using SchoolMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMVC.Repository
{
	public class ClassRepository : IRepository
	{
		public ClassRepository() : base() { }
		public ClassRepository(SchoolDbContext _db) : base(_db) { }
		public async Task Add(Class entity)
		{
			await db.AddAsync(entity);
		}

		public Class FindById(int id)
		{
			return db.Classes
				.Include(x => x.School)
				.SingleOrDefault(x => x.Id == id);
		}

		public List<Class> GetAll()
		{
			return db.Classes
				.Include(x => x.School)
				.OrderByDescending(x => x.Id)
				.ToList();
		}

		public async Task Remove(int id)
		{
			Class _class = await db.Classes
				.Include(x => x.Students)
				.SingleOrDefaultAsync(x => x.Id == id);
			foreach(var item in _class.Students)
			{
				db.Students.Remove(item);
			}
			db.Classes.Remove(_class);
		}

		public async Task Update(Class entity)
		{
			db.Classes.Update(entity);
		}
		public List<School> GetListSchool()
		{
			return db.Schools
				.OrderByDescending(x => x.Id)
				.ToList();
		}
	}
}
