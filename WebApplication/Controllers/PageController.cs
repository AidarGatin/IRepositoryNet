using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;

namespace WebApplication.Controllers
{
	public class PageController : Controller
	{
		private DataManager _datamanager;
		private ServicesManager _servicemanager;

		public PageController(DataManager dataManager)
		{
			_datamanager = dataManager;
			_servicemanager = new ServicesManager(dataManager);

		}

		public IActionResult Index()
		{
			return View();
		}
	}
}