using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiorello_Web_Application.Migrations
{
    public partial class AfetrCategoryDesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bios",
                table: "Bios");

            migrationBuilder.RenameTable(
                name: "Bios",
                newName: "Bio");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bio",
                table: "Bio",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bio",
                table: "Bio");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Bio",
                newName: "Bios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bios",
                table: "Bios",
                column: "Id");
        }
    }
}
