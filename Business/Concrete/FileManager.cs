using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.File;
using Business.ValidationRules.FluentValidation.EducationContent;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
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
    [LogAspect(typeof(FileLogger))]
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

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(FileValidator))]
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

        [SecuredOperation("admin")]
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

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(FileValidator))]
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
