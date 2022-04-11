using Microsoft.EntityFrameworkCore.Migrations;

namespace MineralsApp.DataAccessLayer.Migrations
{
    public partial class many_to_many_between_publication_and_researcher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "researcher_has_publication",
                columns: table => new
                {
                    researcher_id = table.Column<int>(type: "int", nullable: false),
                    publication_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_researcher_has_publication", x => new { x.researcher_id, x.publication_id });
                    table.ForeignKey(
                        name: "FK_researcher_has_publication_publication_publication_id",
                        column: x => x.publication_id,
                        principalTable: "publication",
                        principalColumn: "publication_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_researcher_has_publication_researcher_researcher_id",
                        column: x => x.researcher_id,
                        principalTable: "researcher",
                        principalColumn: "researcher_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_researcher_has_publication_publication_id",
                table: "researcher_has_publication",
                column: "publication_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "researcher_has_publication");
        }
    }
}
