using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApi_Biblioteca.Models;

public class Livro
{
    [Key]
    public int LivroId { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public int EditoraId { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string? Nome { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string? Assunto { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public int? Tombo { get; set; }
    public bool? Status { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string? Autor { get; set; }

    public virtual Editora Editora { get; set; }
    [JsonIgnore]
    public virtual ICollection<ItemEmprestimo> ItemEmprestimo { get; set; }

}