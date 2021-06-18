using Microsoft.EntityFrameworkCore.Migrations;

namespace teste.Data.Migrations
{
    public partial class endereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_UF_UFId",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_UF_Cidade_CidadeId",
                table: "UF");

            migrationBuilder.DropIndex(
                name: "IX_UF_CidadeId",
                table: "UF");

            migrationBuilder.DropColumn(
                name: "CidadeId",
                table: "UF");

            migrationBuilder.RenameColumn(
                name: "UFId",
                table: "Endereco",
                newName: "CidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Endereco_UFId",
                table: "Endereco",
                newName: "IX_Endereco_CidadeId");

            migrationBuilder.AddColumn<int>(
                name: "UFId",
                table: "Cidade",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_UFId",
                table: "Cidade",
                column: "UFId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidade_UF_UFId",
                table: "Cidade",
                column: "UFId",
                principalTable: "UF",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Cidade_CidadeId",
                table: "Endereco",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidade_UF_UFId",
                table: "Cidade");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Cidade_CidadeId",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Cidade_UFId",
                table: "Cidade");

            migrationBuilder.DropColumn(
                name: "UFId",
                table: "Cidade");

            migrationBuilder.RenameColumn(
                name: "CidadeId",
                table: "Endereco",
                newName: "UFId");

            migrationBuilder.RenameIndex(
                name: "IX_Endereco_CidadeId",
                table: "Endereco",
                newName: "IX_Endereco_UFId");

            migrationBuilder.AddColumn<int>(
                name: "CidadeId",
                table: "UF",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UF_CidadeId",
                table: "UF",
                column: "CidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_UF_UFId",
                table: "Endereco",
                column: "UFId",
                principalTable: "UF",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UF_Cidade_CidadeId",
                table: "UF",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
