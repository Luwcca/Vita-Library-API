using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class deleteLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemEmprestimos_Livros_LivroId",
                table: "ItemEmprestimos");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemEmprestimos_Livros_LivroId",
                table: "ItemEmprestimos",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "LivroId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemEmprestimos_Livros_LivroId",
                table: "ItemEmprestimos");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemEmprestimos_Livros_LivroId",
                table: "ItemEmprestimos",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "LivroId");
        }
    }
}
