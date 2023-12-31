using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation.EducationContent
{
    public class EducationContentValidator : AbstractValidator<Entities.Concrete.EducationContent>
    {
        public EducationContentValidator()
        {
            RuleFor(ec => ec.EducationId).NotEmpty().NotEqual(0).WithMessage("Lütfen bir eğitim seçiniz").WithName("Eğitim");

            RuleFor(ec => ec.Title).NotEmpty().MinimumLength(5).MaximumLength(30)
                .WithMessage("Eğitim içerik başlığı en az 5 en fazla 30 karakter olabilir").WithName("Eğitim içerik başlığı");

            RuleFor(ec => ec.Description).NotEmpty().MinimumLength(5).MaximumLength(200)
                .WithMessage("Eğitim içerik açıklaması en az 5 en fazla 200 karakter olabilir.").WithName("Eğitim içerik açıklaması");
        }
    }
}
