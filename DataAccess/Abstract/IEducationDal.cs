using Core.DataAccess;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.Education.Select;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEducationDal : IEntityRepository<Education>
    {
        List<SelectEducationDto> GetAllSelectEducationDto();
    }
}
