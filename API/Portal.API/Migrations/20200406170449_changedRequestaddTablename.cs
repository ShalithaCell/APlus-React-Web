using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.API.Migrations
{
    public partial class changedRequestaddTablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_requestAddTables",
                table: "requestAddTables");

            migrationBuilder.RenameTable(
                name: "requestAddTables",
                newName: "requestAddTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_requestAddTable",
                table: "requestAddTable",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 6, 22, 34, 48, 755, DateTimeKind.Local).AddTicks(9159) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 6, 22, 34, 48, 756, DateTimeKind.Local).AddTicks(6847) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 6, 22, 34, 48, 756, DateTimeKind.Local).AddTicks(6876) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 6, 22, 34, 48, 756, DateTimeKind.Local).AddTicks(6878) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 6, 22, 34, 48, 756, DateTimeKind.Local).AddTicks(6880) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 6, 22, 34, 48, 756, DateTimeKind.Local).AddTicks(6881) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 6, 22, 34, 48, 756, DateTimeKind.Local).AddTicks(6883) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_requestAddTable",
                table: "requestAddTable");

            migrationBuilder.RenameTable(
                name: "requestAddTable",
                newName: "requestAddTables");

            migrationBuilder.AddPrimaryKey(
                name: "PK_requestAddTables",
                table: "requestAddTables",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 5, 23, 2, 28, 52, DateTimeKind.Local).AddTicks(316) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 5, 23, 2, 28, 52, DateTimeKind.Local).AddTicks(7574) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 5, 23, 2, 28, 52, DateTimeKind.Local).AddTicks(7595) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 5, 23, 2, 28, 52, DateTimeKind.Local).AddTicks(7597) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 5, 23, 2, 28, 52, DateTimeKind.Local).AddTicks(7598) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 5, 23, 2, 28, 52, DateTimeKind.Local).AddTicks(7600) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 5, 23, 2, 28, 52, DateTimeKind.Local).AddTicks(7601) });
        }
    }
}
