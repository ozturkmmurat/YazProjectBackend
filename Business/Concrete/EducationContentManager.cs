using Business.Abstract;
using Business.ValidationRules.FluentValidation.Education;
using Business.ValidationRules.FluentValidation.EducationContent;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Education.Select;
using Entities.Dtos.EducationContent.Select;
using Entities.EntityParameter.EducationContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    [LogAspect(typeof(FileLogger))]
    public class EducationContentManager : IEducationContentService
    {
        IEducationContentDal _educationContentDal;
        IFileService _fileService;
        public EducationContentManager(
            IEducationContentDal educationContentDal,
            IFileService fileService)
        {
            _educationContentDal = educationContentDal;
            _fileService = fileService;
        }

        [ValidationAspect(typeof(EducationContentValidator))]
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

        public IDataResult<List<SelectEducationContentDto>> GetAllEdContentByEdId(int educationId)
        {
            var result = _educationContentDal.GetAllEdContentByEdId(educationId);
            if (result != null & result.Count > 0)
            {
                return new SuccessDataResult<List<SelectEducationContentDto>>(result);
            }
            return new ErrorDataResult<List<SelectEducationContentDto>>();
        }

        public IDataResult<EducationContent> MappingEducation(EducationContentFile educationContentFile)
        {
            if (educationContentFile != null)
            {
                EducationContent educationContent = new EducationContent()
                {
                    Id = educationContentFile.EducationId != 0 ? educationContentFile.EducationContentId : 0,
                    EducationId = educationContentFile.EducationId,
                    Title = educationContentFile.Title,
                    Description = educationContentFile.Description
                };
                return new SuccessDataResult<EducationContent>(educationContent);
            }
            return new ErrorDataResult<EducationContent>();
        }

        public IDataResult<File> MappingFile(EducationContentFile educationContentFile)
        {
            if (educationContentFile != null)
            {
                File file = new File()
                {
                    Id = educationContentFile.FileId != 0 ? educationContentFile.FileId : 0,
                    EducationContentId = educationContentFile.EducationContentId,
                    Path = educationContentFile.Path,
                };
                return new SuccessDataResult<File>(file);
            }
            return new ErrorDataResult<File>();
        }

        [TransactionScopeAspect]
        public IResult TsaAdd(EducationContentFile educationContentFile)
        {
            if (educationContentFile != null)
            {
                var mappingEducation = MappingEducation(educationContentFile).Data;
                var addEducation = Add(mappingEducation);
                if (!addEducation.Success)
                {
                    return new ErrorResult();
                }

                educationContentFile.EducationContentId = mappingEducation.Id;
                var mappingFile = MappingFile(educationContentFile).Data;

                var addFile = _fileService.Add(mappingFile, educationContentFile.File);

                if (!addFile.Success)
                {
                    return new ErrorResult();
                }
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        [TransactionScopeAspect]
        public IResult TsaUpdate(EducationContentFile educationContentFile)
        {
            if (educationContentFile != null)
            {
                var mappingEducation = MappingEducation(educationContentFile).Data;
                var addEducation = Update(mappingEducation);
                if (!addEducation.Success)
                {
                    return new ErrorResult();
                }

                educationContentFile.EducationId = mappingEducation.Id;

                IResult updateFile = null;
                if (educationContentFile.Path == null & educationContentFile.Path == "")
                {
                    var result = _fileService.GetById(educationContentFile.FileId).Data;
                    updateFile = _fileService.Update(result, educationContentFile.File);
                }
                else
                {
                    var mappingFile = MappingFile(educationContentFile).Data;
                    updateFile = _fileService.Update(mappingFile, educationContentFile.File);
                }

                if (!updateFile.Success)
                {
                    return new ErrorResult();
                }


                return new SuccessResult();
            }
            return new ErrorResult();
        }

        [ValidationAspect(typeof(EducationContentValidator))]
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
