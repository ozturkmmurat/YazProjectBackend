using Business.Abstract;
using Business.Constans;
using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.UserEducation.Select;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserEducationManager : IUserEducationService
    {
        IUserEducationDal _userEducationDal;
        IEducationService _educationService;
        public UserEducationManager(
            IUserEducationDal userEducationDal,
            IEducationService educationService)
        {
            _userEducationDal = userEducationDal;
            _educationService = educationService;
        }

        public IResult Add(UserEducation userEducation)
        {
            if (userEducation != null)
            {
                IResult check = BusinessRules.Run(CheckEducationQuota(userEducation.EducationId));
                if (check != null)
                {
                    return new ErrorResult(check.Message);
                }
                _userEducationDal.Add(userEducation);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult CheckEducationQuota(int educationId)
        {
            var getEducationLength = _educationService.GetEducationLength(educationId).Data;
            var getUserEducation = GetNoCancelUserEducationLength(educationId).Data;
            if (getEducationLength > getUserEducation)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.QuotaFull);
        }

        public IResult Delete(UserEducation userEducation)
        {
            if (userEducation != null)
            {
                _userEducationDal.Delete(userEducation);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<SelectUserEducationDto>> GetAllSelectUserEducation(int userId)
        {
            var result = _userEducationDal.GetAllSelectUserEducationDtos(userId);
            if (result != null & result.Count > 0)
            {
                return new SuccessDataResult<List<SelectUserEducationDto>>(result);
            }
            return new ErrorDataResult<List<SelectUserEducationDto>>();
        }

        public IDataResult<int> GetNoCancelUserEducationLength(int educationId)
        {
            var result = _userEducationDal.GetAll(x => x.EducationId == educationId && x.Status != 4).Count;
            return new SuccessDataResult<int>(result);
        }

        public IResult Update(UserEducation userEducation)
        {
            if (userEducation != null)
            {
                _userEducationDal.Update(userEducation);
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
