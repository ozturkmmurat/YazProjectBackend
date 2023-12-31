using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.UserEducation.Select
{
    public class SelectUserEdApplicantDto : IDto
    {
        public int UserEducationId { get; set; }
        public int EducationId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
    }
}
