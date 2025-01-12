using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class MenuTableManager : IMenuTableService
	{
		private readonly IMenuTableDal _menuTableDal;

		public MenuTableManager(IMenuTableDal menuTableDal)
		{
			_menuTableDal = menuTableDal;
		}

		public void TAdd(MenuTable entity)
		{
			_menuTableDal.Add(entity);
		}

		public void TChangeMenuTableStatusToFalse(int id)
		{
			_menuTableDal.ChangeMenuTableStatusToFalse(id);
		}

		public void TChangeMenuTableStatusToTrue(int id)
		{
			_menuTableDal.ChangeMenuTableStatusToTrue(id);
		}

		public void TDelete(MenuTable entity)
		{
			_menuTableDal.Delete(entity);
		}

		public List<MenuTable> TGetAll()
		{
			return _menuTableDal.GetAll();
		}

		public MenuTable TGetById(int id)
		{
			return _menuTableDal.GetById(id);
		}

		public int TMenuTableCount()
		{
			return _menuTableDal.MenuTableCount();
		}

		public void TUpdate(MenuTable entity)
		{
			_menuTableDal.Update(entity);
		}
	}
}
