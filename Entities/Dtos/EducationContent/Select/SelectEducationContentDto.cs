using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.EducationContent.Select
{
    public class SelectEducationContentDto : IDto
    {
        public int EducationContentId { get; set; }
        public int FileId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
    }
}
