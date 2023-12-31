﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEducatorDal : EfEntityRepositoryBase<Educator, YazContext>, IEducatorDal
    {
        public EfEducatorDal(YazContext context) : base(context)
        {
        }
    }
}
