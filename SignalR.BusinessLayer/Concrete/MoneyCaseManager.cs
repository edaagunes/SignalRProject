using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class MoneyCaseManager : IMoneyCaseService
	{
		private readonly IMoneyCaseService _moneyCaseService;

		public MoneyCaseManager(IMoneyCaseService moneyCaseService)
		{
			_moneyCaseService = moneyCaseService;
		}


		public void TAdd(MoneyCase entity)
		{
			throw new NotImplementedException();
		}

		public void TDelete(MoneyCase entity)
		{
			throw new NotImplementedException();
		}

		public List<MoneyCase> TGetAll()
		{
			throw new NotImplementedException();
		}

		public MoneyCase TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public decimal TTotalMoney()
		{
			return _moneyCaseService.TTotalMoney();
		}

		public void TUpdate(MoneyCase entity)
		{
			throw new NotImplementedException();
		}
	}
}
