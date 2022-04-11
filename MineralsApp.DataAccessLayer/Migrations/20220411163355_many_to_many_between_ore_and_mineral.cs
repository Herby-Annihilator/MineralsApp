using Microsoft.EntityFrameworkCore.Migrations;

namespace MineralsApp.DataAccessLayer.Migrations
{
    public partial class many_to_many_between_ore_and_mineral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ore_has_mineral",
                columns: table => new
                {
                    ore_id = table.Column<int>(type: "int", nullable: false),
                    mineral_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ore_has_mineral", x => new { x.ore_id, x.mineral_id });
                    table.ForeignKey(
                        name: "FK_ore_has_mineral_mineral_mineral_id",
                        column: x => x.mineral_id,
                        principalTable: "mineral",
                        principalColumn: "mineral_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ore_has_mineral_ore_ore_id",
                        column: x => x.ore_id,
                        principalTable: "ore",
                        principalColumn: "ore_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ore_has_mineral_mineral_id",
                table: "ore_has_mineral",
                column: "mineral_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ore_has_mineral");
        }
    }
}
