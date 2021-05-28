using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolMVC.Models;
using SchoolMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMVC.Controllers
{
	public class ClassController : Controller
	{
		ClassRepository classRepository;
		public ClassController()
		{
			classRepository = new ClassRepository();
		}
		public IActionResult Index()
		{
			return View(classRepository.GetAll());
		}
		public IActionResult AddClass()
		{
			var listSchool = classRepository.GetListSchool();
			ViewBag.listSchool = new SelectList(listSchool, "Id", "Name");
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddClass(Class @class)
		{
			await classRepository.Add(@class);
			await classRepository.SaveChange();
			return RedirectToAction(nameof(Index));
		}
		[Route("class/{slug}-{id:int}")]
		public async Task<IActionResult> Get(int id)
		{
			var @class = classRepository.FindById(id);
			return View(@class);
		}
		public IActionResult Update(int id)
		{
			var listSchool = classRepository.GetListSchool();
			ViewBag.listSchool = new SelectList(listSchool, "Id", "Name");
			return View(classRepository.FindById(id));
		}
		[HttpPost]
		public async Task<IActionResult> Update(Class @class)
		{
			await classRepository.Update(@class);
			await classRepository.SaveChange();
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Delete(int id)
		{
			await classRepository.Remove(id);
			await classRepository.SaveChange();
			return RedirectToAction(nameof(Index));
		}
	} 
}
