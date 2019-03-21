using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities;
using DomainLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Controllers
{
	public class HomeController : Controller
	{
		private EFDBContext _context;
		private IDirectorysRepository _dirRep;

		public HomeController	(EFDBContext context, IDirectorysRepository dirRep )
		{
			_context = context;
			_dirRep = dirRep;
		}
		public IActionResult Index()
		{
			HelloModel _model = new HelloModel() { HelloMessage = "Aidar!" };

			//List<Directory> _dirs = _context.Directory.Include(x=>x.Materials).ToList();
			List<Directory> _dirs = _dirRep.GetAllDirectorys().ToList(); 
		 
			return View(_dirs);
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
