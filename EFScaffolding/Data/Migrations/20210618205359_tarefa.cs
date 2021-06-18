using Microsoft.EntityFrameworkCore.Migrations;

namespace teste.Data.Migrations
{
    public partial class tarefa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioTarefa",
                columns: table => new
                {
                    FuncionariosId = table.Column<int>(type: "int", nullable: false),
                    TarefasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioTarefa", x => new { x.FuncionariosId, x.TarefasId });
                    table.ForeignKey(
                        name: "FK_FuncionarioTarefa_Funcionario_FuncionariosId",
                        column: x => x.FuncionariosId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionarioTarefa_Tarefa_TarefasId",
                        column: x => x.TarefasId,
                        principalTable: "Tarefa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioTarefa_TarefasId",
                table: "FuncionarioTarefa",
                column: "TarefasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionarioTarefa");

            migrationBuilder.DropTable(
                name: "Tarefa");
        }
    }
}
