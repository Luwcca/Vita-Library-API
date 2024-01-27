namespace WebApi_Biblioteca.Models;

public class ItemEmprestimo
{
    public int EmprestimoId { get; set; }
    public int LivroId { get; set; }
    public int PeriodicoId { get; set; }
    public DateTime Devolucao { get; set; }

    public Emprestimo Emprestimo { get; set; }
    public Livro Livro { get; set;}
    public Periodico Periodico { get; set; }

}
