using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation.Educator
{
    public class EducatorValidator : AbstractValidator<Entities.Concrete.Educator>
    {
        public EducatorValidator()
        {
            RuleFor(e => e.FirstName).NotEmpty()
                .MinimumLength(3).MaximumLength(25).WithMessage("Eğitmen adı en az 3 karakter en fazla 25 karakter olabilir.").WithName("Eğitmen Adı");

            RuleFor(e => e.LastName).NotEmpty()
                .MinimumLength(3).MaximumLength(25).WithMessage("Eğitmen soyadı en az 3 karakter en fazla 25 karakter olabilir.").WithName("Eğitmen Soyad");

            RuleFor(e => e.Type).NotEmpty().WithMessage("Eğitim tipi boş geçilemez").WithName("Eğitim Tipi");

            RuleFor(e => e.Title).NotEmpty().MinimumLength(3).MaximumLength(30)
                .WithMessage("Ünvan en fazla 3 karakter en fazla 30 karakter olabilir.").WithName("Ünvan");
        }
    }
}
