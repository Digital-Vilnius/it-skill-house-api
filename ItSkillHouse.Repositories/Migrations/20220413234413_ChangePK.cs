using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItSkillHouse.Repositories.Migrations
{
    public partial class ChangePK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractorsTechnologies",
                table: "ContractorsTechnologies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractorsTechnologies",
                table: "ContractorsTechnologies",
                columns: new[] { "ContractorId", "TechnologyId", "IsMain" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractorsTechnologies",
                table: "ContractorsTechnologies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractorsTechnologies",
                table: "ContractorsTechnologies",
                columns: new[] { "ContractorId", "TechnologyId" });
        }
    }
}
