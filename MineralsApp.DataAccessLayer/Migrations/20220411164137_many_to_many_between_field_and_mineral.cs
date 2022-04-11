using Microsoft.EntityFrameworkCore.Migrations;

namespace MineralsApp.DataAccessLayer.Migrations
{
    public partial class many_to_many_between_field_and_mineral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "field_has_mineral",
                columns: table => new
                {
                    field_id = table.Column<int>(type: "int", nullable: false),
                    mineral_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_field_has_mineral", x => new { x.mineral_id, x.field_id });
                    table.ForeignKey(
                        name: "FK_field_has_mineral_field_field_id",
                        column: x => x.field_id,
                        principalTable: "field",
                        principalColumn: "field_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_field_has_mineral_mineral_mineral_id",
                        column: x => x.mineral_id,
                        principalTable: "mineral",
                        principalColumn: "mineral_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_field_has_mineral_field_id",
                table: "field_has_mineral",
                column: "field_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "field_has_mineral");
        }
    }
}
