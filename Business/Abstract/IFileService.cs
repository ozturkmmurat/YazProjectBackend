using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFileService
    {
        IDataResult<File> GetById(int id);
        IDataResult<List<File>> GetAllByEducationContentId(int educationContentId);
        IResult Add(File file, IFormFile formFile);
        IResult Update(File file, IFormFile formFile);
        IResult Delete(File file);
    }
}
