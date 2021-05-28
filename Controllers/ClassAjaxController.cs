using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolMVC.Models;
using SchoolMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMVC.Controllers
{
	public class ClassAjaxController : Controller
	{
		public ClassRepository classRepository;
		public ClassAjaxController()
		{
			classRepository = new();
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult IndexAjax()
		{
			return Ok(classRepository.GetAll());
		}
		public IActionResult AddClass()
		{
			return View();
		}
		public IActionResult AddClass_Ajax()
		{
			return Ok(classRepository.GetListSchool());
		}
		[HttpPost]
		public async Task<IActionResult> AddClass_Ajax(Class @class)
		{
			await classRepository.Add(@class);
			await classRepository.SaveChange();
			return Ok(true);
		}
	}
}
