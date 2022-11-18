using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laiLaChoCu.Migrations
{
    public partial class AddStatistical1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Statisticals",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Statisticals",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Statisticals",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Statisticals",
                newName: "id");
        }
    }
}
