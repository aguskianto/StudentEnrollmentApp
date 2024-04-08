using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentEnrollmentData.Migrations
{
    /// <inheritdoc />
    public partial class ExtendUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1863db38-9914-4d1b-9519-3c693d70e670");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cbe1b84-1b8e-4d18-aa08-f726075cc65a");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00f04f57-c9ac-460c-a113-4eecc37c5a72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bef33541-f82a-452f-bcdd-97951a130415");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1863db38-9914-4d1b-9519-3c693d70e670", null, "User", "USER" },
                    { "9cbe1b84-1b8e-4d18-aa08-f726075cc65a", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 2, 15, 15, 37, 506, DateTimeKind.Local).AddTicks(5306), new DateTime(2024, 4, 2, 15, 15, 37, 506, DateTimeKind.Local).AddTicks(5339) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 2, 15, 15, 37, 506, DateTimeKind.Local).AddTicks(5344), new DateTime(2024, 4, 2, 15, 15, 37, 506, DateTimeKind.Local).AddTicks(5345) });
        }
    }
}
