using System.ComponentModel.DataAnnotations;

namespace WebApi_Biblioteca.Models;

public class Aluno
{
    [Key]
    public int AlunoId { get; set; }
    public string? Nome { get; set; }
    public int Telefone { get; set; }
    public int CPF { get; set; }
    public string? Rua { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? UF { get; set; }
    public int Multas { get; set; }
    public bool Checkbox { get; set; }
    
    public ICollection<Emprestimo> Emprestimos { get; set; }
}
