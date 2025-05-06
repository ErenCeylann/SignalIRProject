using FluentValidation;
using SignalRDtoLayer.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.ValidationRules.BookingValidation
{
    public class CreateBookingValidation:AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon Alanı Boş Geçilemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alanı Boş Geçilemez!");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi Alanı Boş Geçilemez!");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih Alanı Boş Geçilemez Lütfen Tarih Seçiniz!");

            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Lütfen isim alanına en az 5 karakter giriniz");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Lütfen isim alanına en fazla 50 karakter giriniz");
            RuleFor(x => x.Name).MaximumLength(500).WithMessage("Lütfen açıklama alanına en fazla 500 karakter giriniz");

            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen Geçerli Bir mail adresi giriniz");
       
            
        }
    }
}
