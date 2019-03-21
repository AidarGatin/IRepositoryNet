using System;
using DomainLayer.Interfaces;

namespace DomainLayer
{
	public class DataManager
	{
		private IDirectorysRepository _directorysRepository;
		private IMaterialsRepository _materialsRepository;

		public DataManager(IDirectorysRepository directorysRepository, IMaterialsRepository materialsRepository)
		{
				 _directorysRepository = directorysRepository;
				 _materialsRepository = materialsRepository;
		}

		public IDirectorysRepository Directorys { get { return _directorysRepository; } }
		public IMaterialsRepository Materials { get { return _materialsRepository; } }

}
}
