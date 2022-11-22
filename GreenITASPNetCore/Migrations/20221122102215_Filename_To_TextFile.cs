using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenITASPNetCore.Migrations
{
    public partial class Filename_To_TextFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "TextFiles",
                newName: "Filename");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Filename",
                table: "TextFiles",
                newName: "FileName");
        }
    }
}
