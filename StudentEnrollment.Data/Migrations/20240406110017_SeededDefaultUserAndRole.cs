using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentEnrollmentData.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUserAndRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00f04f57-c9ac-460c-a113-4eecc37c5a72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bef33541-f82a-452f-bcdd-97951a130415");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42358d3e-3c22-45e1-be81-6caa7ba865ef", null, "User", "USER" },
                    { "d1b5952a-2162-46c7-b29e-1a2a68922c14", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3f4631bd-f907-4409-b416-ba356312e659", 0, "33600cca-0147-4481-a873-c309fa40ca41", null, "schooluser@localhost.com", true, "School", "User", false, null, "SCHOOLUSER@LOCALHOST.COM", "SCHOOLUSER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEGAHLvplYV9o52N3p9Jls4wqjONEGXC8TKJyBn5X8XwadGVQdWHtG7lYqfOIWev/UA==", null, false, "0f32b711-5fd4-4dfb-b419-1788dc9c8881", false, "schooluser@localhost.com" },
                    { "408aa945-3d84-4421-8342-7269ec64d949", 0, "4eb14a8f-6fb7-419f-b584-3c9d303254d0", null, "schooladmin@localhost.com", true, "School", "Admin", false, null, "SCHOOLADMIN@LOCALHOST.COM", "SCHOOLADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAECTRcHTx3H2tPviUspiOcdbY6fHe8B8t/xteznUBStogiSJAQGDz4U+CO8TXWdh9HA==", null, false, "f53930c8-e95d-4839-a88e-fda98cd90f0c", false, "schooladmin@localhost.com" }
                });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 6, 18, 0, 14, 167, DateTimeKind.Local).AddTicks(8762), new DateTime(2024, 4, 6, 18, 0, 14, 167, DateTimeKind.Local).AddTicks(8775) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 6, 18, 0, 14, 167, DateTimeKind.Local).AddTicks(8777), new DateTime(2024, 4, 6, 18, 0, 14, 167, DateTimeKind.Local).AddTicks(8778) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "42358d3e-3c22-45e1-be81-6caa7ba865ef", "3f4631bd-f907-4409-b416-ba356312e659" },
                    { "d1b5952a-2162-46c7-b29e-1a2a68922c14", "408aa945-3d84-4421-8342-7269ec64d949" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "42358d3e-3c22-45e1-be81-6caa7ba865ef", "3f4631bd-f907-4409-b416-ba356312e659" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d1b5952a-2162-46c7-b29e-1a2a68922c14", "408aa945-3d84-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42358d3e-3c22-45e1-be81-6caa7ba865ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1b5952a-2162-46c7-b29e-1a2a68922c14");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00f04f57-c9ac-460c-a113-4eecc37c5a72", null, "User", "USER" },
                    { "bef33541-f82a-452f-bcdd-97951a130415", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 6, 17, 24, 8, 750, DateTimeKind.Local).AddTicks(9097), new DateTime(2024, 4, 6, 17, 24, 8, 750, DateTimeKind.Local).AddTicks(9122) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 6, 17, 24, 8, 750, DateTimeKind.Local).AddTicks(9126), new DateTime(2024, 4, 6, 17, 24, 8, 750, DateTimeKind.Local).AddTicks(9128) });
        }
    }
}
