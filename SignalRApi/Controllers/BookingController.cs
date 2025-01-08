using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly IBookingService _bookingService;

		public BookingController(IBookingService bookingService)
		{
			_bookingService = bookingService;
		}

		[HttpGet]
		public IActionResult BookingList()
		{
			return Ok(_bookingService.TGetAll());
		}

		[HttpPost]
		public IActionResult CreateBooking(CreateBookingDto createBookingDto)
		{
			Booking booking = new Booking()
			{
				Date = createBookingDto.Date,
				Mail = createBookingDto.Mail,
				Name = createBookingDto.Name,
				PersonCount = createBookingDto.PersonCount,
				Phone = createBookingDto.Phone,
				Description = "Rezervasyon Alındı"
			};
			_bookingService.TAdd(booking);
			return Ok("Ekleme Başarılı");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteBooking(int id)
		{
			var value = _bookingService.TGetById(id);
			_bookingService.TDelete(value);
			return Ok("Silme Başarılı");
		}
		[HttpPut]
		public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
		{
			Booking booking = new Booking()
			{
				BookingId = updateBookingDto.BookingId,
				Date = updateBookingDto.Date,
				Mail = updateBookingDto.Mail,
				Name = updateBookingDto.Name,
				PersonCount = updateBookingDto.PersonCount,
				Phone = updateBookingDto.Phone,
				Description = updateBookingDto.Description
			};
			_bookingService.TUpdate(booking);
			return Ok("Güncelleme Başarılı");
		}
		[HttpGet("{id}")]
		public IActionResult GetBooking(int id)
		{
			return Ok(_bookingService.TGetById(id));
		}

		[HttpGet("BookingStatusApproved/{id}")]
		public IActionResult BookingStatusApproved(int id)
		{
			_bookingService.TBookingStatusApproved(id);
			return Ok("Rezervasyon Açıklaması Değiştirildi");
		}

		[HttpGet("BookingStatusCanceled/{id}")]
		public IActionResult BookingStatusCanceled(int id)
		{
			_bookingService.TBookingStatusCanceled(id);
			return Ok("Rezervasyon Açıklaması Değiştirildi");
		}
	}
}
