using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.API.Migrations
{
    public partial class updateInventoryTableToInventories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    ProductName = table.Column<string>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<double>(nullable: false),
                    SupplireName = table.Column<string>(nullable: false),
                    SupplireEmail = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 23, 21, 0, 392, DateTimeKind.Local).AddTicks(3820) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 23, 21, 0, 393, DateTimeKind.Local).AddTicks(5018) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 23, 21, 0, 393, DateTimeKind.Local).AddTicks(5052) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 23, 21, 0, 393, DateTimeKind.Local).AddTicks(5055) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 23, 21, 0, 393, DateTimeKind.Local).AddTicks(5057) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 23, 21, 0, 393, DateTimeKind.Local).AddTicks(5059) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 23, 21, 0, 393, DateTimeKind.Local).AddTicks(5061) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    RegistedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    SupplireEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplireName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 19, 24, 18, 493, DateTimeKind.Local).AddTicks(3156) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 19, 24, 18, 494, DateTimeKind.Local).AddTicks(1141) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 19, 24, 18, 494, DateTimeKind.Local).AddTicks(1164) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 19, 24, 18, 494, DateTimeKind.Local).AddTicks(1166) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 19, 24, 18, 494, DateTimeKind.Local).AddTicks(1168) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 19, 24, 18, 494, DateTimeKind.Local).AddTicks(1169) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 19, 24, 18, 494, DateTimeKind.Local).AddTicks(1171) });
        }
    }
}
