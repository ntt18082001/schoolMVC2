using Microsoft.EntityFrameworkCore;
using SchoolMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMVC.Repository
{
	public class StudentRepository : IRepository
	{
		public StudentRepository() : base() { }
		public StudentRepository(SchoolDbContext _db) : base(_db) { }
		public async Task Add(Student entity)
		{
			await db.AddAsync(entity);
		}

		public Student FindById(int id)
		{
			return db.Students
				.Include(x => x.Class)
				.SingleOrDefault(x => x.Id == id);
		}

		public List<Student> GetAll()
		{
			return db.Students.Include(x => x.Class).ToList();
		}

		public async Task Remove(int id)
		{
			Student student = await db.Students.FindAsync(id);
			db.Students.Remove(student);
		}

		public async Task Update(Student entity)
		{
			db.Students.Update(entity);
		}
		public List<Class> GetListClass()
		{
			return db.Classes.ToList();
		}
	}
}
