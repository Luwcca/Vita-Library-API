using System.ComponentModel.DataAnnotations;
using WebApi_Biblioteca.Models;

namespace WebApi_Biblioteca.Data.Dtos.EmprestimoDtos;

public class GetItemEmprestimosDto
{

    public int? LivroId { get; set; }
    public int? PeriodicoId { get; set; }
    public DateTime? Devolucao { get; set; }
    public virtual Emprestimo Emprestimo { get; set; }
}
