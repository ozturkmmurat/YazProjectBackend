using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Education.Select;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class EducationManager : IEducationService
    {
        IEducationDal _educationDal;
        public EducationManager(IEducationDal educationDal)
        {
            _educationDal = educationDal;
        }
        public IResult Add(Education education)
        {
            if (education != null)
            {
                _educationDal.Add(education);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult Delete(Education education)
        {
            if (education != null)
            {
                _educationDal.Delete(education);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<SelectEducationDto>> GetAllSelectEducationDto()
        {
            var result = _educationDal.GetAllSelectEducationDto();
            if (result != null & result.Count > 0)
            {
                return new SuccessDataResult<List<SelectEducationDto>>(result);
            }
            return new ErrorDataResult<List<SelectEducationDto>>();
        }

        public IDataResult<int> GetEducationLength(int id)
        {
            var result = _educationDal.Get(x => x.Id == id).Quota;
            return new SuccessDataResult<int>(result);
        }

        public IResult Update(Education education)
        {
           if (education != null)
            {
                _educationDal.Update(education);
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
