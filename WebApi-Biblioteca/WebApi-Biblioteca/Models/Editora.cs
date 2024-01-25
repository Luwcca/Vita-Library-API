using System.ComponentModel.DataAnnotations;

namespace WebApi_Biblioteca.Models;

public class Editora
{
    [Key]
    public int IdEditora { get; set; }


    public string? Nome { get; set; }
    public string? Endereco { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? UF { get; set; }



}
