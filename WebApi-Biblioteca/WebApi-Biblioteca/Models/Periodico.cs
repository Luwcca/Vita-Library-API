using System.ComponentModel.DataAnnotations;

namespace WebApi_Biblioteca.Models;

public class Periodico
{
    [Key]
    public int PeriodicoId { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string Assunto { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public int? Tombo { get; set; }
    public bool? Status { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string? Autor { get; set; }

    public virtual ICollection<ItemEmprestimo> ItemEmprestimo { get; set; }  
}