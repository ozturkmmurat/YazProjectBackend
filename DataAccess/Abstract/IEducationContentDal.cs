using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.EducationContent.Select;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEducationContentDal : IEntityRepository<EducationContent>
    {
        List<SelectEducationContentDto> GetAllEducationContentByEdId(int educationId);
    }
}
