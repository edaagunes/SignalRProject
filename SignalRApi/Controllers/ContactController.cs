using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		[HttpGet]
		public IActionResult ContactList()
		{
			return Ok(_contactService.TGetAll());
		}

		[HttpPost]
		public IActionResult CreateContact(CreateContactDto createContactDto)
		{
			Contact contact = new Contact()
			{
				Email = createContactDto.Email,
				Phone = createContactDto.Phone,
				FooterDescription = createContactDto.FooterDescription,
				Location = createContactDto.Location,
			};
			_contactService.TAdd(contact);
			return Ok("Ekleme Başarılı");
		}
		[HttpDelete]
		public IActionResult DeleteContact(int id)
		{
			var value = _contactService.TGetById(id);
			_contactService.TDelete(value);
			return Ok("Silme Başarılı");
		}
		[HttpPut]
		public IActionResult UpdateContact(UpdateContactDto updateContactDto)
		{
			Contact contact = new Contact()
			{
				ContactId = updateContactDto.ContactId,
				Email= updateContactDto.Email,
				Phone = updateContactDto.Phone,
				FooterDescription = updateContactDto.FooterDescription,
				Location=updateContactDto.Location,
			};
			_contactService.TUpdate(contact);
			return Ok("Güncelleme Başarılı");
		}
		[HttpGet("GetContact")]
		public IActionResult GetContact(int id)
		{
			return Ok(_contactService.TGetById(id));
		}
	}
}
