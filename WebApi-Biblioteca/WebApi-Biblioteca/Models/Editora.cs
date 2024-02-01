 using System.ComponentModel.DataAnnotations;

namespace WebApi_Biblioteca.Models;

public class Editora
{
    [Key]
    public int EditoraId { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string? Nome { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string? Endereco { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string? Bairro { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string? Cidade { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string? UF { get; set; }

    public virtual ICollection<Livro> Livros { get; set; }

}
