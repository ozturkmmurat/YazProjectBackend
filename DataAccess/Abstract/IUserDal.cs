using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Dtos.User.Select;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        List<SelectUserDto> GetAllUserDto();
    }
}
