using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.Dtos.UserEducation.Select;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserEducationDal : EfEntityRepositoryBase<UserEducation, YazContext>, IUserEducationDal
    {
        public List<SelectUserEducationDto> GetAllSelectUserEducationDtos(int userId)
        {
            using (YazContext context = new YazContext())
            {
                var result = from ue in context.UserEducations
                             join e in context.Educations
                             on ue.EducationId equals e.Id
                             join u in context.Users.Where(x => x.Id == userId)
                             on ue.UserId equals u.Id

                             select new SelectUserEducationDto
                             {
                                 UserEducationId = ue.Id,
                                 EducationId = e.Id,
                                 Status = ue.Status,
                                 EducationTitle = e.Title,
                                 EducationDescription = e.Description,
                                 DailyPrice = e.DailyPrice,
                                 StartDate = e.StartDate,
                                 EndDate = e.EndDate
                             };

                return result.ToList();
            }
        }
    }
}
