using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.API.Migrations
{
    public partial class changedRequestaddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "requestAddTables",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "requestAddTables",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "requestAddTables",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "requestAddTables",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "requestAddTables",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "requestAddTables",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "requestAddTables",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "passwordConfirm",
                table: "requestAddTables",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 21, 49, 42, 976, DateTimeKind.Local).AddTicks(6137) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 21, 49, 42, 977, DateTimeKind.Local).AddTicks(3519) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 21, 49, 42, 977, DateTimeKind.Local).AddTicks(3544) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 21, 49, 42, 977, DateTimeKind.Local).AddTicks(3546) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 21, 49, 42, 977, DateTimeKind.Local).AddTicks(3547) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 21, 49, 42, 977, DateTimeKind.Local).AddTicks(3548) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 21, 49, 42, 977, DateTimeKind.Local).AddTicks(3550) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "requestAddTables");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "requestAddTables");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "requestAddTables");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "requestAddTables");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "requestAddTables");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "requestAddTables");

            migrationBuilder.DropColumn(
                name: "password",
                table: "requestAddTables");

            migrationBuilder.DropColumn(
                name: "passwordConfirm",
                table: "requestAddTables");

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 21, 37, 52, 655, DateTimeKind.Local).AddTicks(3561) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 21, 37, 52, 656, DateTimeKind.Local).AddTicks(2809) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 21, 37, 52, 656, DateTimeKind.Local).AddTicks(2838) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 21, 37, 52, 656, DateTimeKind.Local).AddTicks(2841) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 21, 37, 52, 656, DateTimeKind.Local).AddTicks(2842) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 21, 37, 52, 656, DateTimeKind.Local).AddTicks(2843) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 21, 37, 52, 656, DateTimeKind.Local).AddTicks(2845) });
        }
    }
}
