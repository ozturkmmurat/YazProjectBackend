using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.EducationContent.Select;
using Entities.EntityParameter.EducationContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEducationContentService
    {
        IDataResult<List<SelectEducationContentDto>> GetAllEdContentByEdId(int educationId);
        IResult Add(EducationContent educationContent);
        IResult Update(EducationContent educationContent);
        IResult Delete(EducationContent educationContent);
        IResult TsaAdd(EducationContentFile educationContentFile);
        IResult TsaUpdate(EducationContentFile educationContentFile);
        IDataResult<EducationContent> MappingEducation(EducationContentFile educationContentFile);
        IDataResult<File> MappingFile(EducationContentFile educationContentFile);

    }
}
