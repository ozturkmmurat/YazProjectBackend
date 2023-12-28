using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.Dtos.EducationContent.Select;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEducationContentDal : EfEntityRepositoryBase<EducationContent, YazContext>, IEducationContentDal
    {
        public List<SelectEducationContentDto> GetAllEducationContentByEdId(int educationId)
        {
            using (YazContext context = new YazContext())
            {
                var result = from ec in context.EducationContents.Where(x => x.EducationId == educationId)
                             join f in context.Files
                             on ec.Id equals f.EducationContentId

                             select new SelectEducationContentDto
                             {
                                 EducationContentId = ec.Id,
                                 FileId = f.Id,
                                 Title = ec.Title,
                                 Description = ec.Description,
                                 Path = f.Path
                             };
                return result.ToList();
            }
        }
    }
}
