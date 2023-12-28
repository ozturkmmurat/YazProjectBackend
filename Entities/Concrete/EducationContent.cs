using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //Egitim icerigi
    public class EducationContent : IEntity
    {
        public int Id { get; set; }
        public int EducationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
