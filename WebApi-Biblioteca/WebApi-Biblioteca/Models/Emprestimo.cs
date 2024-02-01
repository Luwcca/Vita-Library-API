using System.ComponentModel.DataAnnotations;

namespace WebApi_Biblioteca.Models;

public class Emprestimo
{
    [Key]
    public int EmprestimoId { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public int AlunoId { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public int FuncionarioId { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [DisplayFormat(DataFormatString = "dd/mm/yyy")]
    public DateTime Hora { get; set; }
    [DisplayFormat(DataFormatString = "dd/mm/yyy")]
    public DateTime? Devolucao { get; set; }

    public virtual Funcionario Funcionario { get; set; }
    public virtual Aluno Aluno { get; set;}
    public virtual ItemEmprestimo ItemEmprestimo { get; set; }
}
