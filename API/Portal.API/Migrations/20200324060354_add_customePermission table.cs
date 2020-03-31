using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.API.Migrations
{
    public partial class add_customePermissiontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customPermissions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    PermissionCode = table.Column<string>(nullable: true),
                    Permission = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customPermissions", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customPermissions");
        }
    }
}
