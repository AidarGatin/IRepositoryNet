using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Model
{
	public class DirectoryViewModel : PageViewModel 
	{
		public Directory Directory { get; set; }
		public List<MaterialViewModel> Materials { get; set; }
	}
	public class DirectoryEditModel : PageEditModel
	{
	}
}
