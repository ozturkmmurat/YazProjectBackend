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
        private readonly YazContext _yazContext;
        public EfEducationContentDal(YazContext context) : base(context)
        {
            _yazContext = context;
        }

        public List<SelectEducationContentDto> GetAllEdContentByEdId(int educationId)
        {
                var result = from ec in _yazContext.EducationContents.Where(x => x.EducationId == educationId)
                             join e in _yazContext.Educations
                             on ec.EducationId equals e.Id
                             join f in _yazContext.Files
                             on ec.Id equals f.EducationContentId

                             select new SelectEducationContentDto
                             {
                                 EducationContentId = ec.Id,
                                 EducationId = e.Id,
                                 FileId = f.Id,
                                 Title = ec.Title,
                                 Description = ec.Description,
                                 Path = f.Path
                             };
                return result.ToList();
        }
    }
}
