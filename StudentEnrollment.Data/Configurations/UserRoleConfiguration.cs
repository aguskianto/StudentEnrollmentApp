using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentData.Configurations
{
    //IdentityRole => IdentityUserRole<string>
    internal class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                //new IdentityRole
                //{
                //    Name = "Administrator",
                //    NormalizedName = "ADMINISTRATOR"
                //},
                //new IdentityRole
                //{
                //    Name = "User",
                //    NormalizedName = "USER"
                //}

                new IdentityUserRole<string>
                {
                    RoleId = "d1b5952a-2162-46c7-b29e-1a2a68922c14",
                    UserId = "408aa945-3d84-4421-8342-7269ec64d949",
                },
                new IdentityUserRole<string>
                {
                    RoleId = "42358d3e-3c22-45e1-be81-6caa7ba865ef",
                    UserId = "3f4631bd-f907-4409-b416-ba356312e659",
                }
            );
        }
    }
}
