using FluentValidation;
using SignalR_DtoLayer.ReservationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_BusinessLayer.ValidationRules.ReservationValidations;

public class CreateReservationRules : AbstractValidator<CreateReservationRequestDto>
{
    public CreateReservationRules()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("İsminizi giriniz.");
        RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon numaranızı giriniz.");
        RuleFor(x => x.Mail).NotEmpty().WithMessage("Email adresinizi giriniz.");
        RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi sayısı giriniz.");
        RuleFor(x => x.Date).NotEmpty().WithMessage("Rezervasyon tarihini seçiniz.");

        RuleFor(x => x.Phone).Length(10).WithMessage("10 Haneli bir numara giriniz.");

        RuleFor(x => x.Mail).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.");
    }
}
