using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Data
{
    public class StudentEnrollmentDbContext: IdentityDbContext
    {
        public StudentEnrollmentDbContext(DbContextOptions<StudentEnrollmentDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());

            //builder.Entity<Course>().HasData(
            //    new Course
            //    {
            //        Id = 1,
            //        Title = "Minimal API Development",
            //        Credits = 3,
            //        CreatedDate = DateTime.Now,
            //        CreatedBy = "Agus Kianto",
            //        ModifiedDate = DateTime.Now,
            //        ModifiedBy = "Agus Kianto"
            //    },
            //    new Course
            //    {
            //        Id = 2,
            //        Title = "Ultimate API Development",
            //        Credits = 5,
            //        CreatedDate = DateTime.Now,
            //        CreatedBy = "Agus Kianto",
            //        ModifiedDate = DateTime.Now,
            //        ModifiedBy = "Agus Kianto"
            //    }
            //);

            //builder.Entity<IdentityRole>().HasData(
            //    new IdentityRole
            //    {
            //        Name = "Administrator",
            //        NormalizedName = "ADMINISTRATOR"
            //    },
            //    new IdentityRole
            //    {
            //        Name = "User",
            //        NormalizedName = "USER"
            //    }
            //);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}
