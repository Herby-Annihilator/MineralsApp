using Microsoft.EntityFrameworkCore.Migrations;

namespace MineralsApp.DataAccessLayer.Migrations
{
    public partial class try_to_configure_many_to_many_relationship_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_publication_describes_mineral_mineral_MineralsId",
                table: "publication_describes_mineral");

            migrationBuilder.DropForeignKey(
                name: "FK_publication_describes_mineral_publication_PublicationsId",
                table: "publication_describes_mineral");

            migrationBuilder.RenameColumn(
                name: "PublicationsId",
                table: "publication_describes_mineral",
                newName: "publication_id");

            migrationBuilder.RenameColumn(
                name: "MineralsId",
                table: "publication_describes_mineral",
                newName: "mineral_id");

            migrationBuilder.RenameIndex(
                name: "IX_publication_describes_mineral_PublicationsId",
                table: "publication_describes_mineral",
                newName: "IX_publication_describes_mineral_publication_id");

            migrationBuilder.AddForeignKey(
                name: "FK_publication_describes_mineral_mineral_mineral_id",
                table: "publication_describes_mineral",
                column: "mineral_id",
                principalTable: "mineral",
                principalColumn: "mineral_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_publication_describes_mineral_publication_publication_id",
                table: "publication_describes_mineral",
                column: "publication_id",
                principalTable: "publication",
                principalColumn: "publication_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_publication_describes_mineral_mineral_mineral_id",
                table: "publication_describes_mineral");

            migrationBuilder.DropForeignKey(
                name: "FK_publication_describes_mineral_publication_publication_id",
                table: "publication_describes_mineral");

            migrationBuilder.RenameColumn(
                name: "publication_id",
                table: "publication_describes_mineral",
                newName: "PublicationsId");

            migrationBuilder.RenameColumn(
                name: "mineral_id",
                table: "publication_describes_mineral",
                newName: "MineralsId");

            migrationBuilder.RenameIndex(
                name: "IX_publication_describes_mineral_publication_id",
                table: "publication_describes_mineral",
                newName: "IX_publication_describes_mineral_PublicationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_publication_describes_mineral_mineral_MineralsId",
                table: "publication_describes_mineral",
                column: "MineralsId",
                principalTable: "mineral",
                principalColumn: "mineral_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_publication_describes_mineral_publication_PublicationsId",
                table: "publication_describes_mineral",
                column: "PublicationsId",
                principalTable: "publication",
                principalColumn: "publication_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
