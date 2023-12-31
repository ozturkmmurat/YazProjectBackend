using Core.DataAccess.EntityFramework;
using Core.Utilities.Result.Abstract;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.Dtos.Education.Select;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEducationDal : EfEntityRepositoryBase<Education, YazContext>, IEducationDal
    {
        private readonly YazContext _yazContext;
        public EfEducationDal(YazContext context) : base(context)
        {
            _yazContext = context;
        }

        public List<SelectEducationDto> GetAllSelectEducationDto()
        {
                var result = from e in _yazContext.Educations
                             join ed in _yazContext.Educators
                             on e.EducatorId equals ed.Id

                             select new SelectEducationDto
                             {
                                 EducationId = e.Id,
                                 EducatorId = ed.Id,
                                 EducatorFirstName = ed.FirstName,
                                 EducatorLastName = ed.LastName,
                                 EducatorTitle = ed.Title,
                                 EducatorType = ed.Type,
                                 EducationDescription = e.Description,
                                 EducationTitle = e.Title,
                                 Type = e.Type,
                                 Quota = e.Quota,
                                 DailyPrice = e.DailyPrice,
                                 StartDate = e.StartDate,
                                 EndDate = e.EndDate
                             };

                return result.ToList();
        }
    }
}
