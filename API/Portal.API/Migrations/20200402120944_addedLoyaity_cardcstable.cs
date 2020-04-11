using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.API.Migrations
{
    public partial class addedLoyaity_cardcstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "loyaity_Card",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    no_of_point = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loyaity_Card", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 17, 39, 43, 864, DateTimeKind.Local).AddTicks(4726) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 17, 39, 43, 865, DateTimeKind.Local).AddTicks(4525) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 17, 39, 43, 865, DateTimeKind.Local).AddTicks(4553) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 17, 39, 43, 865, DateTimeKind.Local).AddTicks(4555) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 17, 39, 43, 865, DateTimeKind.Local).AddTicks(4557) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 17, 39, 43, 865, DateTimeKind.Local).AddTicks(4558) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 17, 39, 43, 865, DateTimeKind.Local).AddTicks(4560) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "loyaity_Card");

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 15, 37, 34, 624, DateTimeKind.Local).AddTicks(7520) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 15, 37, 34, 626, DateTimeKind.Local).AddTicks(553) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 15, 37, 34, 626, DateTimeKind.Local).AddTicks(588) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 15, 37, 34, 626, DateTimeKind.Local).AddTicks(590) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 15, 37, 34, 626, DateTimeKind.Local).AddTicks(592) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 15, 37, 34, 626, DateTimeKind.Local).AddTicks(593) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 2, 15, 37, 34, 626, DateTimeKind.Local).AddTicks(595) });
        }
    }
}
