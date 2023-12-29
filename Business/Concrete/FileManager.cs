using Business.Abstract;
using Business.Constans;
using Core.Helpers.FileHelper;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FileManager : IFileService
    {
        IFileDal _fileDal;
        IFileHelper _fileHelper;
        public FileManager(
            IFileDal fileDal,
            IFileHelper fileHelper)
        {
            _fileDal = fileDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(File file, IFormFile formFile)
        {
            if (file != null)
            {
                file.Path = _fileHelper.Upload(formFile, PathConstans.ImagesPath);
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

        public IDataResult<File> GetById(int id)
        {
            var result = _fileDal.Get(x => x.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<File>(result);
            }
            return new ErrorDataResult<File>();
        }

        public IResult Update(File file, IFormFile formFile)
        {
            if (file != null)
            {
                if(formFile != null)
                {
                    file.Path = _fileHelper.Upload(formFile, PathConstans.ImagesPath);
                }
                _fileDal.Update(file);
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
