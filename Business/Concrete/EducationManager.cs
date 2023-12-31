using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.File;
using Business.ValidationRules.FluentValidation.Education;
using Business.ValidationRules.FluentValidation.Educator;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
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
    [LogAspect(typeof(FileLogger))]
    public class EducationManager : IEducationService
    {
        IEducationDal _educationDal;
        public EducationManager(IEducationDal educationDal)
        {
            _educationDal = educationDal;
        }

        [ValidationAspect(typeof(EducationValidator))]
        [SecuredOperation("admin")]
        public IResult Add(Education education)
        {
            if (education != null)
            {
                _educationDal.Add(education);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        [ValidationAspect(typeof(EducationValidator))]
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

        [ValidationAspect(typeof(EducationValidator))]
        [SecuredOperation("admin")]
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
