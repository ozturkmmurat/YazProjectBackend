using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public class YazContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-K1G3PAC;Database=YazProject;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer("Server=YAYIN01;Database=YazProject; User ID=murat;Password=123456;Connect Timeout=30;MultiSubnetFailover=False;");
            }
        }

        public DbSet<Education> Educations { get; set; }
        public DbSet<Educator> Educators { get; set; }
        public DbSet<EducationContent> EducationContents { get; set; }
        public DbSet<UserEducation> UserEducations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<File> Files { get; set; }
    }
}
