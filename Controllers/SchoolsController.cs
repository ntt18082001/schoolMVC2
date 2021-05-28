using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolMVC.Models;
using SchoolMVC.Repository;

namespace SchoolMVC.Controllers
{
    public class SchoolsController : Controller
    {
		public SchoolRepository schoolRepository;
		public SchoolsController()
		{
			schoolRepository = new SchoolRepository();
		}
		// GET: Schools
		public IActionResult Index()
        {
            return View(schoolRepository.GetAll());
        }
		public JsonResult IndexAjax()
		{
			return Json(schoolRepository.GetAll());
		}
		// GET: Schools/Details/...
		public async Task<IActionResult> Details(int id)
		{
			var school = schoolRepository.FindById(id);
			return View(school);
		}
		public async Task<JsonResult> DetailsAjax(int id)
		{
			var school = schoolRepository.FindById(id);
			return Json(school);
		}
		// GET: Schools/Create
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(School school)
		{
			await schoolRepository.Add(school);
			await schoolRepository.SaveChange();
			return RedirectToAction(nameof(Index));
		}
		[HttpPost]
		public async Task<JsonResult> CreateAjax(School school)
		{
			await schoolRepository.Add(school);
			await schoolRepository.SaveChange();
			return Json(true);
		}
		// GET: Schools/Edit/5
		public IActionResult Edit(int id)
		{
			var school = schoolRepository.FindById(id);
			return View(school);
		}
		//// POST: Schools/Edit/...
		[HttpPost]
		public async Task<IActionResult> Edit(School school)
		{
			await schoolRepository.Update(school);
			await schoolRepository.SaveChange();
			return RedirectToAction(nameof(Index));
		}
		public JsonResult EditAjax(int id)
		{
			var school = schoolRepository.FindById(id);
			return Json(school);
		}
		[HttpPost]
		public async Task<JsonResult> EditAjax(School school)
		{
			await schoolRepository.Update(school);
			await schoolRepository.SaveChange();
			return Json(true);
		}
		// GET: Schools/Delete/...
		public async Task<IActionResult> Delete(int id)
		{
			await schoolRepository.Remove(id);
			await schoolRepository.SaveChange();
			return RedirectToAction(nameof(Index));
		}
		[HttpDelete]
		public async Task<JsonResult> DeleteAjax(int id)
		{
			await schoolRepository.Remove(id);
			await schoolRepository.SaveChange();
			return Json(true);
		}
	}
}
