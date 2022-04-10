using Microsoft.EntityFrameworkCore.Migrations;

namespace MineralsApp.DataAccessLayer.Migrations
{
    public partial class add_column_name_to_country_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_territory_country_CountryId",
                table: "territory");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "territory",
                newName: "country_id");

            migrationBuilder.RenameIndex(
                name: "IX_territory_CountryId",
                table: "territory",
                newName: "IX_territory_country_id");

            migrationBuilder.AddForeignKey(
                name: "FK_territory_country_country_id",
                table: "territory",
                column: "country_id",
                principalTable: "country",
                principalColumn: "country_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_territory_country_country_id",
                table: "territory");

            migrationBuilder.RenameColumn(
                name: "country_id",
                table: "territory",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_territory_country_id",
                table: "territory",
                newName: "IX_territory_CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_territory_country_CountryId",
                table: "territory",
                column: "CountryId",
                principalTable: "country",
                principalColumn: "country_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
