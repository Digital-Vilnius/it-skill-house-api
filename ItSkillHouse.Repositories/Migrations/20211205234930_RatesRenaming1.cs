using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItSkillHouse.Repositories.Migrations
{
    public partial class RatesRenaming1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractorRates_Contractors_ContractorId",
                table: "ContractorRates");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_ContractorRates_ContractorRateId",
                table: "Contracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractorRates",
                table: "ContractorRates");

            migrationBuilder.RenameTable(
                name: "ContractorRates",
                newName: "Rates");

            migrationBuilder.RenameColumn(
                name: "ContractorRateId",
                table: "Contracts",
                newName: "RateId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_ContractorRateId",
                table: "Contracts",
                newName: "IX_Contracts_RateId");

            migrationBuilder.RenameIndex(
                name: "IX_ContractorRates_ContractorId",
                table: "Rates",
                newName: "IX_Rates_ContractorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rates",
                table: "Rates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Rates_RateId",
                table: "Contracts",
                column: "RateId",
                principalTable: "Rates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Contractors_ContractorId",
                table: "Rates",
                column: "ContractorId",
                principalTable: "Contractors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Rates_RateId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Contractors_ContractorId",
                table: "Rates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rates",
                table: "Rates");

            migrationBuilder.RenameTable(
                name: "Rates",
                newName: "ContractorRates");

            migrationBuilder.RenameColumn(
                name: "RateId",
                table: "Contracts",
                newName: "ContractorRateId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_RateId",
                table: "Contracts",
                newName: "IX_Contracts_ContractorRateId");

            migrationBuilder.RenameIndex(
                name: "IX_Rates_ContractorId",
                table: "ContractorRates",
                newName: "IX_ContractorRates_ContractorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractorRates",
                table: "ContractorRates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractorRates_Contractors_ContractorId",
                table: "ContractorRates",
                column: "ContractorId",
                principalTable: "Contractors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_ContractorRates_ContractorRateId",
                table: "Contracts",
                column: "ContractorRateId",
                principalTable: "ContractorRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
