using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentEnrollment.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5f8f001-dbf4-4fdd-868d-36c105d97ac3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d19753e8-b0f1-4f98-882a-909828144312");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1863db38-9914-4d1b-9519-3c693d70e670");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cbe1b84-1b8e-4d18-aa08-f726075cc65a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a5f8f001-dbf4-4fdd-868d-36c105d97ac3", null, "User", "USER" },
                    { "d19753e8-b0f1-4f98-882a-909828144312", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 2, 13, 25, 59, 340, DateTimeKind.Local).AddTicks(2248), new DateTime(2024, 4, 2, 13, 25, 59, 340, DateTimeKind.Local).AddTicks(2276) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 2, 13, 25, 59, 340, DateTimeKind.Local).AddTicks(2283), new DateTime(2024, 4, 2, 13, 25, 59, 340, DateTimeKind.Local).AddTicks(2285) });
        }
    }
}
