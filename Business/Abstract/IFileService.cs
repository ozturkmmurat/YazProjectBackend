using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFileService
    {
        IDataResult<List<File>> GetAllByEducationContentId(int educationContentId);
        IResult Add(File file);
        IResult Update(File file);
        IResult Delete(File file);
    }
}
