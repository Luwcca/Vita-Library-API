using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<int>(type: "int", nullable: false),
                    CPF = table.Column<int>(type: "int", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimos",
                columns: table => new
                {
                    EmprestimoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Devolucao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimos", x => x.EmprestimoId);
                    table.ForeignKey(
                        name: "FK_Emprestimos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emprestimos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemEmprestimos",
                columns: table => new
                {
                    ItemEmprestimoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmprestimoId = table.Column<int>(type: "int", nullable: false),
                    LivroId = table.Column<int>(type: "int", nullable: false),
                    PeriodicoId = table.Column<int>(type: "int", nullable: false),
                    Devolucao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemEmprestimos", x => x.ItemEmprestimoId);
                    table.ForeignKey(
                        name: "FK_ItemEmprestimos_Emprestimos_EmprestimoId",
                        column: x => x.EmprestimoId,
                        principalTable: "Emprestimos",
                        principalColumn: "EmprestimoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemEmprestimos_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "LivroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemEmprestimos_Periodicos_PeriodicoId",
                        column: x => x.PeriodicoId,
                        principalTable: "Periodicos",
                        principalColumn: "PeriodicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_AlunoId",
                table: "Emprestimos",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_FuncionarioId",
                table: "Emprestimos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemEmprestimos_EmprestimoId",
                table: "ItemEmprestimos",
                column: "EmprestimoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemEmprestimos_LivroId",
                table: "ItemEmprestimos",
                column: "LivroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemEmprestimos_PeriodicoId",
                table: "ItemEmprestimos",
                column: "PeriodicoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemEmprestimos");

            migrationBuilder.DropTable(
                name: "Emprestimos");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
