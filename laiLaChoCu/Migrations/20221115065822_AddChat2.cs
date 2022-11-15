using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laiLaChoCu.Migrations
{
    public partial class AddChat2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Chats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Chats");
        }
    }
}
