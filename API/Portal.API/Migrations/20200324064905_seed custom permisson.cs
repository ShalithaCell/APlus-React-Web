using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.API.Migrations
{
    public partial class seedcustompermisson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "customPermissions",
                columns: new[] { "ID", "IsActive", "Permission", "PermissionCode", "RegistedDate" },
                values: new object[,]
                {
                    { 1, true, "Report", "RE", new DateTime(2020, 3, 24, 12, 19, 5, 303, DateTimeKind.Local).AddTicks(8217) },
                    { 2, true, "Sales", "SE", new DateTime(2020, 3, 24, 12, 19, 5, 306, DateTimeKind.Local).AddTicks(1094) },
                    { 3, true, "Inventory View", "IV", new DateTime(2020, 3, 24, 12, 19, 5, 306, DateTimeKind.Local).AddTicks(1138) },
                    { 4, true, "Inventory Add", "IA", new DateTime(2020, 3, 24, 12, 19, 5, 306, DateTimeKind.Local).AddTicks(1141) },
                    { 5, true, "Inventory Update", "IU", new DateTime(2020, 3, 24, 12, 19, 5, 306, DateTimeKind.Local).AddTicks(1143) },
                    { 6, true, "Inventory Delete", "ID", new DateTime(2020, 3, 24, 12, 19, 5, 306, DateTimeKind.Local).AddTicks(1145) },
                    { 7, true, "Customer Handling", "CH", new DateTime(2020, 3, 24, 12, 19, 5, 306, DateTimeKind.Local).AddTicks(1147) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 7);
        }
    }
}
