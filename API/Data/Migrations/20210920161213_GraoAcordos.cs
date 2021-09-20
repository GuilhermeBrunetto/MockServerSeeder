using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class GraoAcordos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Graos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graos", x => x.Id);
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
                    GraoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acordos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acordos_Graos_GraoId",
                        column: x => x.GraoId,
                        principalTable: "Graos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acordos_GraoId",
                table: "Acordos",
                column: "GraoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acordos");

            migrationBuilder.DropTable(
                name: "Graos");
        }
    }
}
