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
    public class FileManager : IFileService
    {
        IFileDal _fileDal;
        public FileManager(IFileDal fileDal)
        {
            _fileDal = fileDal;
        }
        public IResult Add(File file)
        {
            if (file != null)
            {
                _fileDal.Add(file);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult Delete(File file)
        {
            if (file != null)
            {
                _fileDal.Delete(file);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<File>> GetAllByEducationContentId(int educationContentId)
        {
            var result = _fileDal.GetAll(x => x.EducationContentId == educationContentId);
            if (result != null)
            {
                return new SuccessDataResult<List<File>>(result);
            }
            return new ErrorDataResult<List<File>>();
        }

        public IResult Update(File file)
        {
            if (file != null)
            {
                _fileDal.Update(file);
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
