 using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
    [JsonIgnore]
    public virtual ICollection<Livro> Livros { get; set; }

}
