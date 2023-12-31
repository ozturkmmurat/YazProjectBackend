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
        private readonly YazContext _yazContext;
        public EfUserEducationDal(YazContext context) : base(context)
        {
            _yazContext = context;
        }

        public List<SelectUserEdApplicantDto> GetAllEducationApplicant(int educationId)
        {
            var result = from ue in _yazContext.UserEducations.Where(x => x.EducationId == educationId)
                         join u in _yazContext.Users
                         on ue.UserId equals u.Id

                         select new SelectUserEdApplicantDto
                         {
                             UserEducationId = ue.Id,
                             EducationId = ue.EducationId,
                             UserId = u.Id,
                             Status = ue.Status,
                             FirstName= u.FirstName,
                             LastName= u.LastName,
                             Email= u.Email
                         };
            return result.ToList();
        }

        public List<SelectUserEducationDto> GetAllSelectUserEducationDtos(int userId)
        {
            var result = from ue in _yazContext.UserEducations
                         join e in _yazContext.Educations
                         on ue.EducationId equals e.Id
                         join u in _yazContext.Users.Where(x => x.Id == userId)
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

