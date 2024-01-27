using System.ComponentModel.DataAnnotations;

namespace WebApi_Biblioteca.Models;

public class Emprestimo
{
    [Key]
    public int EmprestimoId { get; set; }
    public int AlunoId { get; set; }
    public int FuncionarioId { get; set; }
    public DateTime Hora { get; set; }
    public DateTime Devolucao { get; set; }

    public Funcionario Funcionario { get; set; }
    public Aluno Aluno { get; set;}
    public ItemEmprestimo ItemEmprestimos { get; set; }
}
