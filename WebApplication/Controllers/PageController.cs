using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using PresentationLayer.Model;
using static DataLayer.Enums.PageEnums;

namespace WebApplication.Controllers
{
	public class PageController : Controller
	{
		private DataManager _dataManager;
		private ServicesManager _servicemanager;

		public PageController(DataManager dataManager)
		{
			_dataManager = dataManager;
			_servicemanager = new ServicesManager(dataManager);

		}

		public IActionResult Index(int pageId, PageType pageType)
		{
			PageViewModel _viewModel;
			switch (pageType)
			{
				case PageType.Directory: _viewModel = _servicemanager.Directorys.DirectoryDBToViewModelById(pageId); break;
				case PageType.Material: _viewModel = _servicemanager.Materials.MaterialDBModelToView(pageId); break;
				default: _viewModel = null; break;
			}
			ViewBag.PageType = pageType;
			return View(_viewModel);
		}

    [HttpGet]
    public IActionResult PageEditor(int pageId, PageType pageType, int directoryId = 0)
    {
      PageEditModel _editModel;

      switch (pageType)
      {
        case PageType.Directory:
          if (pageId != 0) _editModel = _servicemanager.Directorys.GetDirectoryEdetModel(pageId);
          else _editModel = _servicemanager.Directorys.CreateNewDirectoryEditModel();
          break;
        case PageType.Material:
          if (pageId != 0) _editModel = _servicemanager.Materials.GetMaterialEditModel(pageId);
          else _editModel = _servicemanager.Materials.CreateNewMaterialEditModel(directoryId);
          break;
        default: _editModel = null; break;
      }

      ViewBag.PageType = pageType;
      return View(_editModel);
    }

    [HttpPost]
    public IActionResult SaveDirectory(DirectoryEditModel model)
    {
      _servicemanager.Directorys.SaveDirectoryEditModelToDb(model);
      return RedirectToAction("PageEditor", "Page", new { pageId = model.Id, pageType = PageType.Directory });
    }

    [HttpPost]
    public IActionResult SaveMaterial(MaterialEditModel model)
    {
      _servicemanager.Materials.SaveMaterialEditModelToDb(model);
      return RedirectToAction("PageEditor", "Page", new { pageId = model.Id, pageType = PageType.Material });
    }
  }
}