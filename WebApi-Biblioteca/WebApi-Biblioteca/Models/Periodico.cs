using System.ComponentModel.DataAnnotations;

namespace WebApi_Biblioteca.Models;

public class Periodico
{
    [Key]
    public int PeriodicoId { get; set; }

    public string? Nome { get; set; }
    public string? Assunto { get; set; }
    public int? Tombo { get; set; }
    public bool? Status { get; set; }
    public string? Autor { get; set; }

    public ItemEmprestimo ItemEmprestimo { get; set; }  
}