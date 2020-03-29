using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.API.Migrations
{
    public partial class changeTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "testDatas",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "testDatas",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 28, 21, 57, 29, 136, DateTimeKind.Local).AddTicks(1953) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 28, 21, 57, 29, 138, DateTimeKind.Local).AddTicks(6418) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 28, 21, 57, 29, 138, DateTimeKind.Local).AddTicks(6465) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 28, 21, 57, 29, 138, DateTimeKind.Local).AddTicks(6468) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 28, 21, 57, 29, 138, DateTimeKind.Local).AddTicks(6471) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 28, 21, 57, 29, 138, DateTimeKind.Local).AddTicks(6473) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 28, 21, 57, 29, 138, DateTimeKind.Local).AddTicks(6474) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "testDatas");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "testDatas");

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 28, 21, 52, 2, 923, DateTimeKind.Local).AddTicks(7168) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 28, 21, 52, 2, 926, DateTimeKind.Local).AddTicks(3279) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 28, 21, 52, 2, 926, DateTimeKind.Local).AddTicks(3331) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 28, 21, 52, 2, 926, DateTimeKind.Local).AddTicks(3334) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 28, 21, 52, 2, 926, DateTimeKind.Local).AddTicks(3336) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 28, 21, 52, 2, 926, DateTimeKind.Local).AddTicks(3337) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 28, 21, 52, 2, 926, DateTimeKind.Local).AddTicks(3339) });
        }
    }
}
