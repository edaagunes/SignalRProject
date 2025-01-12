using FluentValidation;
using SignalR.DtoLayer.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.ValidationRules.BookingValidations
{
	public class CreateBookingValidation:AbstractValidator<CreateBookingDto>
	{
		public CreateBookingValidation()
		{
			RuleFor(x=>x.Name).NotEmpty().WithMessage("Ad Soyad giriniz");
			RuleFor(x=>x.Phone).NotEmpty().WithMessage("Telefon giriniz");
			RuleFor(x=>x.Mail).NotEmpty().WithMessage("Mail adresinizi giriniz");
			RuleFor(x => x.PersonCount).NotNull().WithMessage("Kişi sayısı boş geçilemez");
			RuleFor(x => x.Date).NotNull().WithMessage("Lütfen tarih seçiniz");


			RuleFor(x => x.Name).MinimumLength(5).WithMessage("En az 5 karakter giriniz").MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapılabilir");
			RuleFor(x => x.Description).MinimumLength(5).WithMessage("En az 5 karakter giriniz").MaximumLength(500).WithMessage("En fazla 500 karakter girişi yapılabilir");

			RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz");
		
		}
	}
}
