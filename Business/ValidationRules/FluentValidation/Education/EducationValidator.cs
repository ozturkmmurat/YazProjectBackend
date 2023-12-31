using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation.Education
{
    public class EducationValidator : AbstractValidator<Entities.Concrete.Education>
    {
        public EducationValidator()
        {
            RuleFor(e => e.EducatorId).NotEmpty().NotEqual(0).WithMessage("Eğitmen giriniz.").WithName("Eğitmen");

            RuleFor(e => e.Title).NotEmpty().MinimumLength(5).MaximumLength(50)
                .WithMessage("Eğitim başlığı en az 5 en fazla 50 karakter olabilir").WithName("Başlık");

            RuleFor(e => e.Description).NotEmpty().MinimumLength(10).MaximumLength(200)
                .WithMessage("Eğitim açıklaması en az 10 karakter en fazla 200 karakter olabilir").WithName("Eğitim Açıklaması");

            RuleFor(e => e.DailyPrice).NotEmpty().GreaterThan(0).WithMessage("Eğitim ücreti 0 ve 0 dan düşük olamaz").WithName("Ücret");

            RuleFor(x => x.StartDate)
             .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Başlangıç tarihi bugünün tarihinden önce olamaz")
             .LessThanOrEqualTo(x => x.EndDate).WithMessage("Başlangıç tarihi bitiş tarihinden sonra olamaz").WithName("Tarih");
        }
    }
}