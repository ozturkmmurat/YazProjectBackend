using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.File
{
    public class FileValidator : AbstractValidator<Entities.Concrete.File>
    {
        public FileValidator()
        {
            RuleFor(f => f.EducationContentId).NotEmpty().NotEqual(0)
                .WithMessage("Lütfen döküman yüklemek istediğiniz eğitim içeriğini seçiniz").WithName("Eğitim içeriği");
        }
    }
}
