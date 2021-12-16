using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItSkillHouse.Repositories.Migrations
{
    public partial class Location : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Contractors",
                newName: "CountryCode");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Contractors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Contractors");

            migrationBuilder.RenameColumn(
                name: "CountryCode",
                table: "Contractors",
                newName: "Location");
        }
    }
}
