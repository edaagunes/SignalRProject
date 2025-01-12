using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.EntityFramework;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class BasketManager : IBasketService
	{
		private readonly IBasketDal _basketDal;

		public BasketManager(IBasketDal basketDal)
		{
			_basketDal = basketDal;
		}

		public void TAdd(Basket entity)
		{
			_basketDal.Add(entity);
		}

		public void TDelete(Basket entity)
		{
			_basketDal.Delete(entity);
		}

		public void TDeleteBasketByMenuTableId(int menuTableId)
		{
			_basketDal.DeleteBasketByMenuTableId(menuTableId);
		}

		public List<Basket> TGetAll()
		{
			throw new NotImplementedException();
		}

		public List<Basket> TGetBasketByMenuTableNumber(int id)
		{
			return _basketDal.GetBasketByMenuTableNumber(id);
		}

		public Basket TGetById(int id)
		{
			return _basketDal.GetById(id);
		}

		public decimal TTotalPriceBasketByMenuTableId(int menuTableId)
		{
			return _basketDal.TotalPriceBasketByMenuTableId(menuTableId);
		}

		public void TUpdate(Basket entity)
		{
			throw new NotImplementedException();
		}
	}
}
