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
    public class EducationContentManager : IEducationContentService
    {
        IEducationContentDal _educationContentDal;
        public EducationContentManager(IEducationContentDal educationContentDal)
        {
            _educationContentDal = educationContentDal;
        }
        public IResult Add(EducationContent educationContent)
        {
            if (educationContent != null)
            {
                _educationContentDal.Add(educationContent);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult Delete(EducationContent educationContent)
        {
            if (educationContent != null)
            {
                _educationContentDal.Delete(educationContent);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<EducationContent>> GetAllByEducationId(int educationId)
        {
            var result = _educationContentDal.GetAll(x => x.EducationId == educationId);
            if (result != null & result.Count > 0)
            {
                return new SuccessDataResult<List<EducationContent>>(result);
            }
            return new ErrorDataResult<List<EducationContent>>();
        }

        public IResult Update(EducationContent educationContent)
        {
            if (educationContent != null)
            {
                _educationContentDal.Update(educationContent);
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
