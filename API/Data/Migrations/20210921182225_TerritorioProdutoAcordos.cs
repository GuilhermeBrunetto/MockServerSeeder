using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class TerritorioProdutoAcordos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "Territorios",
                columns: table => new
                {
                    TerritorioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Bolsa = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Territorios", x => x.TerritorioId);
                });

            migrationBuilder.CreateTable(
                name: "Acordos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Contrato = table.Column<string>(type: "TEXT", nullable: false),
                    Moeda = table.Column<string>(type: "TEXT", nullable: false),
                    Variacao = table.Column<string>(type: "TEXT", nullable: false),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acordos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acordos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TerritorioProduto",
                columns: table => new
                {
                    TerritorioId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerritorioProduto", x => new { x.TerritorioId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_TerritorioProduto_Produtos_TerritorioId",
                        column: x => x.TerritorioId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TerritorioProduto_Territorios_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Territorios",
                        principalColumn: "TerritorioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acordos_ProdutoId",
                table: "Acordos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_TerritorioProduto_ProdutoId",
                table: "TerritorioProduto",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acordos");

            migrationBuilder.DropTable(
                name: "TerritorioProduto");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Territorios");
        }
    }
}
