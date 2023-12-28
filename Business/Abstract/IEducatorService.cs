using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEducatorService
    {
        IDataResult<List<Educator>> GetAll();
        IResult Add(Educator educator);
        IResult Update(Educator educator);
        IResult Delete(Educator educator);
    }
}
