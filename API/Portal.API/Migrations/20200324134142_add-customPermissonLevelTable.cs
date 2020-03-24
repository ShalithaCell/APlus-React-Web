using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.API.Migrations
{
    public partial class addcustomPermissonLevelTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customRolePermissionLevels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    FK_CustomPermisson = table.Column<int>(nullable: false),
                    FK_RoleID = table.Column<int>(nullable: false),
                    Allowed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customRolePermissionLevels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_customRolePermissionLevels_customPermissions_FK_CustomPermisson",
                        column: x => x.FK_CustomPermisson,
                        principalTable: "customPermissions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customRolePermissionLevels_AspNetRoles_FK_RoleID",
                        column: x => x.FK_RoleID,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 24, 19, 11, 41, 649, DateTimeKind.Local).AddTicks(7470) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 24, 19, 11, 41, 652, DateTimeKind.Local).AddTicks(2593) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 24, 19, 11, 41, 652, DateTimeKind.Local).AddTicks(2637) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 24, 19, 11, 41, 652, DateTimeKind.Local).AddTicks(2640) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 24, 19, 11, 41, 652, DateTimeKind.Local).AddTicks(2642) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 24, 19, 11, 41, 652, DateTimeKind.Local).AddTicks(2644) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 24, 19, 11, 41, 652, DateTimeKind.Local).AddTicks(2646) });

            migrationBuilder.CreateIndex(
                name: "IX_customRolePermissionLevels_FK_CustomPermisson",
                table: "customRolePermissionLevels",
                column: "FK_CustomPermisson");

            migrationBuilder.CreateIndex(
                name: "IX_customRolePermissionLevels_FK_RoleID",
                table: "customRolePermissionLevels",
                column: "FK_RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customRolePermissionLevels");

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 24, 12, 19, 5, 303, DateTimeKind.Local).AddTicks(8217) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 24, 12, 19, 5, 306, DateTimeKind.Local).AddTicks(1094) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 24, 12, 19, 5, 306, DateTimeKind.Local).AddTicks(1138) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 24, 12, 19, 5, 306, DateTimeKind.Local).AddTicks(1141) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 24, 12, 19, 5, 306, DateTimeKind.Local).AddTicks(1143) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 24, 12, 19, 5, 306, DateTimeKind.Local).AddTicks(1145) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 24, 12, 19, 5, 306, DateTimeKind.Local).AddTicks(1147) });
        }
    }
}
