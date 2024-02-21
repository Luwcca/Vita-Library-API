using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class deletePeriodico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemEmprestimos_Periodicos_PeriodicoId",
                table: "ItemEmprestimos");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemEmprestimos_Periodicos_PeriodicoId",
                table: "ItemEmprestimos",
                column: "PeriodicoId",
                principalTable: "Periodicos",
                principalColumn: "PeriodicoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemEmprestimos_Periodicos_PeriodicoId",
                table: "ItemEmprestimos");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemEmprestimos_Periodicos_PeriodicoId",
                table: "ItemEmprestimos",
                column: "PeriodicoId",
                principalTable: "Periodicos",
                principalColumn: "PeriodicoId");
        }
    }
}
