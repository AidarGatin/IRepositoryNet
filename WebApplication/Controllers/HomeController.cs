using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities;
using DomainLayer;
using DomainLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentationLayer;
using PresentationLayer.Model;
using WebApplication.Models;

namespace WebApplication.Controllers
{
	public class HomeController : Controller
	{
		private EFDBContext _context;
		private IDirectorysRepository _dirRep;
		private DataManager _dataManager;
		private ServicesManager _servicesmanager;

		public HomeController	(EFDBContext context, IDirectorysRepository dirRep , DataManager dataManager)
		{
			_context = context;
			_dirRep = dirRep;
			//_dataManager = dataManager;
			_servicesmanager = new ServicesManager(_dataManager); 
		}
		public IActionResult Index()
		{
			HelloModel _model = new HelloModel() { HelloMessage = "Aidar!" };

			//List<Directory> _dirs = _context.Directory.Include(x=>x.Materials).ToList(); // Get from Database context

			//List<Directory> _dirs = _dirRep.GetAllDirectorys().ToList(); // Get from Repository

			//List<Directory> _dirs = _dataManager.Directorys.GetAllDirectorys(true).ToList(); //Get from DataManager 

			List<DirectoryViewModel> _dirs = _servicesmanager.Directorys.GetDirectoryesList(); //Get from DataBase converted  


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
