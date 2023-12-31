using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Dtos.User.Select;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, YazContext>, IUserDal
    {
        private readonly YazContext _yazContext;
        public EfUserDal(YazContext context) : base(context)
        {
            _yazContext = context;
        }
        public List<OperationClaim> GetClaims(User user)
        {
                var result = from operationClaim in _yazContext.OperationClaims
                             join userOperationClaim in _yazContext.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

                return result.ToList();
        }

        public List<SelectUserDto> GetAllUserDto()
        {
                var result = from u in _yazContext.Users
                             join uop in _yazContext.UserOperationClaims
                             on u.Id equals uop.UserId
                             into userOperationClaimTemp
                             from uopt in userOperationClaimTemp.DefaultIfEmpty()
                             join op in _yazContext.OperationClaims
                             on uopt.OperationClaimId equals op.Id
                              into operationClaimTemp
                             from opct in operationClaimTemp.DefaultIfEmpty()

                             select new SelectUserDto
                             {
                                 UserOperationClaimId = uopt.Id,
                                 OperationClaimId = opct.Id,
                                 UserId = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 Status = u.Status,
                                 OperationClaimName = opct.Name,
                             };

                return result.ToList();
        }
    }
}
