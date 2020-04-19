using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.API.Migrations
{
    public partial class Bracnch_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    OrgName = table.Column<string>(nullable: false),
                    OrgLocation = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "branches",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    BranchName = table.Column<string>(nullable: false),
                    OrgName = table.Column<string>(nullable: false),
                    BranchLocation = table.Column<string>(nullable: false),
                    BranchPhone = table.Column<string>(nullable: false),
                    NoofEmployees = table.Column<string>(nullable: false),
                    OrganizationID = table.Column<int>(nullable: true),
                    OrganizationFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_branches_organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "organizations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 4, 20, 8, 12, 870, DateTimeKind.Local).AddTicks(8336) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 4, 20, 8, 12, 872, DateTimeKind.Local).AddTicks(101) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 4, 20, 8, 12, 872, DateTimeKind.Local).AddTicks(130) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 4, 20, 8, 12, 872, DateTimeKind.Local).AddTicks(133) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 4, 20, 8, 12, 872, DateTimeKind.Local).AddTicks(135) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 4, 20, 8, 12, 872, DateTimeKind.Local).AddTicks(136) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 4, 4, 20, 8, 12, 872, DateTimeKind.Local).AddTicks(138) });

            migrationBuilder.CreateIndex(
                name: "IX_branches_OrganizationID",
                table: "branches",
                column: "OrganizationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "branches");

            migrationBuilder.DropTable(
                name: "organizations");

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 30, 17, 2, 51, 927, DateTimeKind.Local).AddTicks(899) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 30, 17, 2, 51, 929, DateTimeKind.Local).AddTicks(5818) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 30, 17, 2, 51, 929, DateTimeKind.Local).AddTicks(5864) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 30, 17, 2, 51, 929, DateTimeKind.Local).AddTicks(5867) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 30, 17, 2, 51, 929, DateTimeKind.Local).AddTicks(5869) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 30, 17, 2, 51, 929, DateTimeKind.Local).AddTicks(5870) });

            migrationBuilder.UpdateData(
                table: "customPermissions",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "IsActive", "RegistedDate" },
                values: new object[] { true, new DateTime(2020, 3, 30, 17, 2, 51, 929, DateTimeKind.Local).AddTicks(5872) });
        }
    }
}
