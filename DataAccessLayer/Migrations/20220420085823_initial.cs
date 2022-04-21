using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WordDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordDefinitions_Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordMeanings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Meaning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LangId = table.Column<int>(type: "int", nullable: false),
                    WordDefinitionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordMeanings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordMeanings_Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WordMeanings_WordDefinitions_WordDefinitionId",
                        column: x => x.WordDefinitionId,
                        principalTable: "WordDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WordDefinitions_LangId",
                table: "WordDefinitions",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_WordMeanings_LangId",
                table: "WordMeanings",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_WordMeanings_WordDefinitionId",
                table: "WordMeanings",
                column: "WordDefinitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WordMeanings");

            migrationBuilder.DropTable(
                name: "WordDefinitions");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
