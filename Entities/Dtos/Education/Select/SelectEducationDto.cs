using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.Education.Select
{
    public class SelectEducationDto : IDto
    {
        public int EducationId { get; set; }
        public int EducatorId { get; set; }
        public string EducatorFirstName { get; set; }
        public string EducatorLastName { get; set; }
        public string EducatorTitle { get; set; }
        public string EducatorType { get; set; }
        public string EducationTitle { get; set; }
        public string EducationDescription { get; set; }
        public string Type { get; set; }
        public int Quota { get; set; }
        public decimal DailyPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
