using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfBasketDal : GenericRepository<Basket>, IBasketDal
	{
		public EfBasketDal(SignalRContext context) : base(context)
		{
		}

		public void DeleteBasketByMenuTableId(int menuTableId)
		{
			using var context = new SignalRContext();
			var basketsToDelete = context.Baskets.Where(x => x.MenuTableId == menuTableId).ToList();
			context.Baskets.RemoveRange(basketsToDelete);
			context.SaveChanges();
		}

		public List<Basket> GetBasketByMenuTableNumber(int id)
		{
			using var context = new SignalRContext();
			var values=context.Baskets.Where(x=>x.MenuTableId == id).Include(y=>y.Product).ToList();
			return values;
		}

		public decimal TotalPriceBasketByMenuTableId(int menuTableId)
		{
			using var context = new SignalRContext();
			var basketPrice = context.Baskets.Where(x => x.MenuTableId == menuTableId).Sum(x => x.TotalPrice);
			return basketPrice;
		}
	}
}
