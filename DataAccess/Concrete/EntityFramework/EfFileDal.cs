using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFileDal : EfEntityRepositoryBase<File, YazContext>, IFileDal
    {
        public EfFileDal(YazContext context) : base(context)
        {
        }
    }
}
