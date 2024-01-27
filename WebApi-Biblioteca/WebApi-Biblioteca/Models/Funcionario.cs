using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApi_Biblioteca.Models;

public class Funcionario : IdentityUser
{
    [Key]
    public int FuncionarioId{ get; set; }
    public string? Nome { get; set; }
    public int Telefone { get; set; }
    public int CPF { get; set; }
    public string? Rua { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? UF { get; set; }

    public string? Login {  get; set; }     
    public string? Senha { get; set;}

    public ICollection<Emprestimo> Emprestimos { get; set; }
}
