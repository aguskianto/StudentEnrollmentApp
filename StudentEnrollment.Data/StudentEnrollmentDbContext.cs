﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using StudentEnrollmentData.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentData
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

    public class StudentEnrollmentDbContextFactory : IDesignTimeDbContextFactory<StudentEnrollmentDbContext>
    {
        public StudentEnrollmentDbContext CreateDbContext(string[] args)
        {
            // Get environment
            //string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Build config
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Get connection string
            var optionsBuilder = new DbContextOptionsBuilder<StudentEnrollmentDbContext>();
            var connectionString = config.GetConnectionString("StudentEnrollmentDbConnection");
            optionsBuilder.UseSqlServer(connectionString);
            return new StudentEnrollmentDbContext(optionsBuilder.Options);
        }
    }
}
