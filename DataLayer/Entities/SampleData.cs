using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Entities
{
	public static class SampleData
	{
		public static void InitData (EFDBContext context)
		{
			if (!context.Directory.Any())
			{
				context.Directory.Add(new Entities.Directory() { Title = "First Directory", Html = "<b>First Directory Content</b>" });
				context.Directory.Add(new Entities.Directory() { Title = "Second Directory", Html = "<b>Second Directory Content</b>" });
				context.SaveChanges();

				context.Material.Add(new Entities.Material() { Title = "First Material", Html = "<b>First Material Content</b>", DirectoryId = context.Directory.First().Id });
				context.Material.Add(new Entities.Material() { Title = "Second Material", Html = "<b>Second Material Content</b>", DirectoryId = context.Directory.First().Id });
				context.Material.Add(new Entities.Material() { Title = "Third Material", Html = "<b>Third Material Content</b>", DirectoryId = context.Directory.Last().Id });
				context.SaveChanges();
			}
		}

	}
}
