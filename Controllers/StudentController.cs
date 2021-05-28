using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolMVC.Models;
using SchoolMVC.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMVC.Controllers
{
	public class StudentController : Controller
	{
		private StudentRepository studentRepository;
		public StudentController()
		{
			studentRepository = new StudentRepository();
		}
		public IActionResult Index()
		{
			return View(studentRepository.GetAll());
		}
		public IActionResult AddStudent()
		{
			var listClass = studentRepository.GetListClass();
			ViewBag.listClass = new SelectList(listClass, "Id", "ClassName");
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddStudent(Student student) 
		{
			var file = Request.Form.Files;
			if(file.Count == 1)
			{
				var fullPath = Directory.GetCurrentDirectory() + "/wwwroot/img/" + file[0].FileName;
				var stream = System.IO.File.Create(fullPath);
				await file[0].CopyToAsync(stream);
				stream.Dispose();
				student.Avatar = file[0].FileName;
			}
			await studentRepository.Add(student);
			await studentRepository.SaveChange();
			return RedirectToAction(nameof(Index));
		}
		[Route("student/{slug}-{id:int}")]
		public async Task<IActionResult> Get(int id)
		{
			var student = studentRepository.FindById(id);
			return View(student);
		}
		public IActionResult Update(int id)
		{
			var listClass = studentRepository.GetListClass();
			ViewBag.listClass = new SelectList(listClass, "Id", "ClassName");
			return View(studentRepository.FindById(id));
		}
		[HttpPost]
		public async Task<IActionResult> Update(Student student)
		{
			await studentRepository.Update(student);
			await studentRepository.SaveChange();
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Delete(int id)
		{
			await studentRepository.Remove(id);
			await studentRepository.SaveChange();
			return RedirectToAction(nameof(Index));
		}
	}
}
