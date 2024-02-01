using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoLivroPeriodico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemEmprestimos_LivroId",
                table: "ItemEmprestimos");

            migrationBuilder.DropIndex(
                name: "IX_ItemEmprestimos_PeriodicoId",
                table: "ItemEmprestimos");

            migrationBuilder.CreateIndex(
                name: "IX_ItemEmprestimos_LivroId",
                table: "ItemEmprestimos",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemEmprestimos_PeriodicoId",
                table: "ItemEmprestimos",
                column: "PeriodicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemEmprestimos_LivroId",
                table: "ItemEmprestimos");

            migrationBuilder.DropIndex(
                name: "IX_ItemEmprestimos_PeriodicoId",
                table: "ItemEmprestimos");

            migrationBuilder.CreateIndex(
                name: "IX_ItemEmprestimos_LivroId",
                table: "ItemEmprestimos",
                column: "LivroId",
                unique: true,
                filter: "[LivroId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ItemEmprestimos_PeriodicoId",
                table: "ItemEmprestimos",
                column: "PeriodicoId",
                unique: true,
                filter: "[PeriodicoId] IS NOT NULL");
        }
    }
}
