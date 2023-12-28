using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEducationContentService
    {
        IDataResult<List<EducationContent>> GetAllByEducationId(int educationId);
        IResult Add(EducationContent educationContent);
        IResult Update(EducationContent educationContent);
        IResult Delete(EducationContent educationContent);
    }
}
