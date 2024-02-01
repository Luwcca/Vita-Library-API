using System.ComponentModel.DataAnnotations;

namespace WebApi_Biblioteca.Models;

public class Aluno
{
    [Key]
    public int AlunoId { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string? Nome { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public int? Telefone { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public int? CPF { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string? Rua { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string? Bairro { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string? Cidade { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string? UF { get; set; }
    public int? Multas { get; set; }
    public bool Checkbox { get; set; }
    
    public virtual ICollection<Emprestimo> Emprestimos { get; set; }
}
