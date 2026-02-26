using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updata_PermissionTable_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sua",
                table: "Menu_Group");

            migrationBuilder.DropColumn(
                name: "Them",
                table: "Menu_Group");

            migrationBuilder.DropColumn(
                name: "Xem",
                table: "Menu_Group");

            migrationBuilder.DropColumn(
                name: "Xoa",
                table: "Menu_Group");

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Module = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Action = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermission_ChucVu",
                        column: x => x.RoleId,
                        principalTable: "ChucVu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.AddColumn<bool>(
                name: "Sua",
                table: "Menu_Group",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Them",
                table: "Menu_Group",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Xem",
                table: "Menu_Group",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Xoa",
                table: "Menu_Group",
                type: "boolean",
                nullable: true);
        }
    }
}
