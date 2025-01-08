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
	public class BookingManager : IBookingService
	{
		private readonly IBookingDal _bookingDal;

		public BookingManager(IBookingDal bookingDal)
		{
			_bookingDal = bookingDal;
		}

		public void TBookingStatusApproved(int id)
		{
			_bookingDal.BookingStatusApproved(id);
		}

		public void TBookingStatusCanceled(int id)
		{
			_bookingDal.BookingStatusCanceled(id);
		}

		public void TAdd(Booking entity)
		{
			_bookingDal.Add(entity);
		}

		public void TDelete(Booking entity)
		{
			_bookingDal.Delete(entity);
		}

		public List<Booking> TGetAll()
		{
			return _bookingDal.GetAll();
		}

		public Booking TGetById(int id)
		{
			return _bookingDal.GetById(id);
		}

		public void TUpdate(Booking entity)
		{
			_bookingDal.Update(entity);
		}
	}
}
