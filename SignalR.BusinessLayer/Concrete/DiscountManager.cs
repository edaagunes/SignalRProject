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
	public class DiscountManager : IDiscountService
	{
		private readonly IDiscountDal _discountDal;

		public DiscountManager(IDiscountDal discountDal)
		{
			_discountDal = discountDal;
		}

		public void TAdd(Discount entity)
		{
			_discountDal.Add(entity);
		}

		public void TChangeStatusToFalse(int id)
		{
			_discountDal.ChangeStatusToFalse(id);
		}

		public void TChangeStatusToTrue(int id)
		{
			_discountDal.ChangeStatusToTrue(id);
		}

		public void TDelete(Discount entity)
		{
			_discountDal.Delete(entity);
		}

		public List<Discount> TGetAll()
		{
			return _discountDal.GetAll();
		}

		public Discount TGetById(int id)
		{
			return _discountDal.GetById(id);
		}

		public List<Discount> TGetListByStatusTrue()
		{
			return _discountDal.GetListByStatusTrue();
		}

		public void TUpdate(Discount entity)
		{
			_discountDal.Update(entity);
		}
	}
}
