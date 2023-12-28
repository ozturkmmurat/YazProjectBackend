using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.UserEducation.Select;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserEducationDal : IEntityRepository<UserEducation>
    {
        List<SelectUserEducationDto> GetAllSelectUserEducationDtos(int userId);
    }
}
