﻿using Core.DataAccess.EntityFramework;
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
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new YazContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

                return result.ToList();
            }
        }

        public List<SelectUserDto> GetAllUserDto()
        {
            using (YazContext context = new YazContext())
            {
                var result = from u in context.Users
                             join uop in context.UserOperationClaims
                             on u.Id equals uop.UserId
                             into userOperationClaimTemp
                             from uopt in userOperationClaimTemp.DefaultIfEmpty()
                             join op in context.OperationClaims
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
}
