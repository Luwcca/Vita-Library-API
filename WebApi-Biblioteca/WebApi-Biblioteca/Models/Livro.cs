using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_Biblioteca.Models;

public class Livro
{
    [Key]
    public int LivroId { get; set; }

    
    public int EditoraId { get; set; }
    

    public string? Nome { get; set; }
    public string? Assunto { get; set; }
    public int? Tombo { get; set; }
    public bool? Status { get; set; }
    public string? Autor { get; set; }

    public Editora Editora { get; set; }

    public ItemEmprestimo ItemEmprestimo { get; set; }

}