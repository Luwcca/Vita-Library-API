using System.ComponentModel.DataAnnotations;

namespace WebApi_Biblioteca.Models;

public class Funcionario
{
    [Key]
    public int FuncionarioId { get; set; }
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
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string? Login { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MinLength(5)]
    [DataType(DataType.Password)]
    public string? Senha { get; set; }

    public virtual ICollection<Emprestimo> Emprestimos { get; set; }
}
