using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApi_Biblioteca.Models;

public class ItemEmprestimo
{
    [Key]
    public int ItemEmprestimoId { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public int EmprestimoId { get; set; }
    public int? LivroId { get; set; }
    public int? PeriodicoId { get; set; }
    [DisplayFormat(DataFormatString = "dd/mm/yyy")]
    public DateTime? Devolucao { get; set; }

    public virtual Emprestimo Emprestimo { get; set; }
    public virtual Livro Livro { get; set;}
    public virtual Periodico Periodico { get; set; }

}
