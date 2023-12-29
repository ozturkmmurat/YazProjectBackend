using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.EntityParameter.EducationContent
{
    public class EducationContentFile
    {
        public int EducationContentId { get; set; }
        public int EducationId { get; set; }
        public int FileId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}
