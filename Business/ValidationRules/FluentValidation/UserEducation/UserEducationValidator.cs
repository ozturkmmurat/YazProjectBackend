using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation.UserEducation
{
    public class UserEducationValidator : AbstractValidator<Entities.Concrete.UserEducation>
    {
        public UserEducationValidator()
        {
            RuleFor(ue => ue.EducationId).NotEmpty().NotEqual(0).WithMessage("Lütfen eğitim seçiniz").WithName("Eğitim");
        }
    }
}
