using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.Education.Select;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEducationService
    {
        IDataResult<List<SelectEducationDto>> GetAllSelectEducationDto();
        IDataResult<int> GetEducationLength(int id);
        IResult Add(Education education);
        IResult Update(Education education);
        IResult Delete(Education education);
    }
}
