using System.ComponentModel.DataAnnotations;

namespace WebApi_Biblioteca.Models;

public class ItemEmprestimo
{
    [Key]
    public int ItemEmprestimoId { get; set; }
    public int EmprestimoId { get; set; }
    public int LivroId { get; set; }
    public int PeriodicoId { get; set; }
    public DateTime Devolucao { get; set; }

    public Emprestimo Emprestimo { get; set; }
    public Livro Livro { get; set;}
    public Periodico Periodico { get; set; }

}
