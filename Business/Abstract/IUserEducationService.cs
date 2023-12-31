using Business.Concrete;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.UserEducation.Select;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserEducationService
    {
        IDataResult<List<SelectUserEdApplicantDto>> GetAllEducationApplicant(int educationId);
        IDataResult<List<SelectUserEducationDto>> GetAllSelectUserEducation(int userId);
        IDataResult<UserEducation> GetByUserEducation(int userId, int educationId);
        IDataResult<int> GetNoCancelUserEducationLength(int educationId);
        IResult CheckEducationQuota(int educationId);
        IResult CheckuserEducation(int userId, int eduationId);
        IResult Add(UserEducation userEducation);
        IResult Update(UserEducation userEducation);
        IResult Delete(UserEducation userEducation);
    }
}
