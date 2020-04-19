using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.API.Migrations
{
    public partial class changeAttendanceTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 11, 13, 40, 30, 58, DateTimeKind.Local).AddTicks(8081) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 11, 13, 40, 30, 59, DateTimeKind.Local).AddTicks(5349) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 11, 13, 40, 30, 59, DateTimeKind.Local).AddTicks(5376) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 11, 13, 40, 30, 59, DateTimeKind.Local).AddTicks(5379) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 11, 13, 40, 30, 59, DateTimeKind.Local).AddTicks(5380) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 11, 13, 40, 30, 59, DateTimeKind.Local).AddTicks(5381) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 11, 13, 40, 30, 59, DateTimeKind.Local).AddTicks(5383) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 11, 13, 30, 34, 872, DateTimeKind.Local).AddTicks(2721) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 11, 13, 30, 34, 873, DateTimeKind.Local).AddTicks(502) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 11, 13, 30, 34, 873, DateTimeKind.Local).AddTicks(530) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 11, 13, 30, 34, 873, DateTimeKind.Local).AddTicks(532) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 11, 13, 30, 34, 873, DateTimeKind.Local).AddTicks(533) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 11, 13, 30, 34, 873, DateTimeKind.Local).AddTicks(534) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 11, 13, 30, 34, 873, DateTimeKind.Local).AddTicks(535) });
        }
    }
}
