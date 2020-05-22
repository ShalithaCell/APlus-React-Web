using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.API.Migrations
{
    public partial class deleteTwoColumInRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "requestAddTable");

            migrationBuilder.DropColumn(
                name: "passwordConfirm",
                table: "requestAddTable");

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 5, 19, 13, 32, 19, 71, DateTimeKind.Local).AddTicks(6564) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 5, 19, 13, 32, 19, 72, DateTimeKind.Local).AddTicks(4045) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 5, 19, 13, 32, 19, 72, DateTimeKind.Local).AddTicks(4070) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 5, 19, 13, 32, 19, 72, DateTimeKind.Local).AddTicks(4072) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 5, 19, 13, 32, 19, 72, DateTimeKind.Local).AddTicks(4073) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 5, 19, 13, 32, 19, 72, DateTimeKind.Local).AddTicks(4074) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 5, 19, 13, 32, 19, 72, DateTimeKind.Local).AddTicks(4075) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "requestAddTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "passwordConfirm",
                table: "requestAddTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 5, 17, 18, 13, 8, 494, DateTimeKind.Local).AddTicks(4804) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 5, 17, 18, 13, 8, 495, DateTimeKind.Local).AddTicks(2128) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 5, 17, 18, 13, 8, 495, DateTimeKind.Local).AddTicks(2158) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 5, 17, 18, 13, 8, 495, DateTimeKind.Local).AddTicks(2160) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 5, 17, 18, 13, 8, 495, DateTimeKind.Local).AddTicks(2161) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 5, 17, 18, 13, 8, 495, DateTimeKind.Local).AddTicks(2162) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 5, 17, 18, 13, 8, 495, DateTimeKind.Local).AddTicks(2164) });
        }
    }
}
