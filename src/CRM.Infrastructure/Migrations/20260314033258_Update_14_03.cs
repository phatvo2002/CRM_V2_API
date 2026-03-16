using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_14_03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoanhSoDuKien",
                table: "NguoiDung");

            migrationBuilder.DropColumn(
                name: "DoanhSoThucTe",
                table: "NguoiDung");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DoanhSoDuKien",
                table: "NguoiDung",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DoanhSoThucTe",
                table: "NguoiDung",
                type: "numeric",
                nullable: true);
        }
    }
}
