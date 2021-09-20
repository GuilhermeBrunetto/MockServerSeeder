using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class TerritorioProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Graos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
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
                name: "IX_Graos_ProdutoId",
                table: "Graos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_TerritorioProduto_ProdutoId",
                table: "TerritorioProduto",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Graos_Produtos_ProdutoId",
                table: "Graos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Graos_Produtos_ProdutoId",
                table: "Graos");

            migrationBuilder.DropTable(
                name: "TerritorioProduto");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Territorios");

            migrationBuilder.DropIndex(
                name: "IX_Graos_ProdutoId",
                table: "Graos");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Graos");
        }
    }
}
