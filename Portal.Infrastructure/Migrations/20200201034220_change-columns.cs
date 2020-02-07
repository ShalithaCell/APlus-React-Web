using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Infrastructure.Migrations
{
    public partial class changecolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Organization",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Organization",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "ID", "Address1", "Address2", "Address3", "Country", "Hearaboutus", "IsActive", "OrganizationName", "RegistedDate", "State", "ZipPostalCode" },
                values: new object[] { 1, "Kuliyapitiya", "Kuliyapitiya", "Kuliyapitiya", "Srilanka", "NVIVID", true, "NVIVID Technologies", new DateTime(2020, 2, 1, 9, 12, 20, 202, DateTimeKind.Local).AddTicks(4674), "Kurunegala", "60200" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organization",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "Organization",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Country",
                table: "Organization",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
