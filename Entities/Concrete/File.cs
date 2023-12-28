using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class File : IEntity
    {
        public int Id { get; set; }
        public int EducationContentId { get; set; }
        public string Path { get; set; }
    }
}
