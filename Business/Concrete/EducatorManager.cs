using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class EducatorManager : IEducatorService
    {
        IEducatorDal _educatorDal;
        public EducatorManager(IEducatorDal educatorDal)
        {
            _educatorDal = educatorDal;
        }
        public IResult Add(Educator educator)
        {
            if (educator != null)
            {
                _educatorDal.Add(educator);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult Delete(Educator educator)
        {
            if (educator != null)
            {
                _educatorDal.Delete(educator);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<Educator>> GetAll()
        {
            var result = _educatorDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Educator>>(result);
            }
            return new ErrorDataResult<List<Educator>>();
        }

        public IResult Update(Educator educator)
        {
            if (educator != null)
            {
                _educatorDal.Update(educator);
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
