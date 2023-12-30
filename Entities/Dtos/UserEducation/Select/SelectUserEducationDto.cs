using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.UserEducation.Select
{
    public class SelectUserEducationDto : IDto
    {
        public int UserEducationId { get; set; }
        public int EducationId { get; set; }
        public string EducationTitle { get; set; }
        public string EducationDescription { get; set; }
        public decimal DailyPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
    }
}
