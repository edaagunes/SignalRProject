using AutoMapper;
using FluentValidation;
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
		private readonly IMapper _mapper;
		private readonly IValidator<CreateBookingDto> _validator;

		public BookingController(IBookingService bookingService, IMapper mapper, IValidator<CreateBookingDto> validator)
		{
			_bookingService = bookingService;
			_mapper = mapper;
			_validator = validator;
		}

		[HttpGet]
		public IActionResult BookingList()
		{
			var values = _bookingService.TGetAll();
			return Ok(_mapper.Map<List<ResultBookingDto>>(values));
		}

		[HttpPost]
		public IActionResult CreateBooking([FromBody] CreateBookingDto createBookingDto)
		{
			var validationResult = _validator.Validate(createBookingDto);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors);
			}

			var value = _mapper.Map<Booking>(createBookingDto);
			_bookingService.TAdd(value);
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
			var value = _mapper.Map<Booking>(updateBookingDto);
			_bookingService.TUpdate(value);
			return Ok("Güncelleme Başarılı");
		}
		[HttpGet("{id}")]
		public IActionResult GetBooking(int id)
		{
			var value = _bookingService.TGetById(id);
			return Ok(_mapper.Map<GetBookingDto>(value));
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
