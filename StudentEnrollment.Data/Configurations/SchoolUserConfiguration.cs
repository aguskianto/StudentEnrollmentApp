﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentData.Configurations
{
    internal class SchoolUserConfiguration : IEntityTypeConfiguration<SchoolUser>
    {
        public void Configure(EntityTypeBuilder<SchoolUser> builder)
        {
            var hasher = new PasswordHasher<SchoolUser>();

            builder.HasData(
                new SchoolUser
                {
                    Id = "408aa945-3d84-4421-8342-7269ec64d949",
                    Email = "schooladmin@localhost.com",
                    NormalizedEmail = "SCHOOLADMIN@LOCALHOST.COM",
                    NormalizedUserName = "SCHOOLADMIN@LOCALHOST.COM",
                    UserName = "schooladmin@localhost.com",
                    FirstName = "School",
                    LastName = "Admin",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true
                },
                new SchoolUser
                {
                    Id = "3f4631bd-f907-4409-b416-ba356312e659",
                    Email = "schooluser@localhost.com",
                    NormalizedEmail = "SCHOOLUSER@LOCALHOST.COM",
                    NormalizedUserName = "SCHOOLUSER@LOCALHOST.COM",
                    UserName = "schooluser@localhost.com",
                    FirstName = "School",
                    LastName = "User",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true
                }
            );
        }
    }
}
