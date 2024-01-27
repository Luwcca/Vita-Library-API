using Microsoft.EntityFrameworkCore;
using WebApi_Biblioteca.Models;

namespace WebApi_Biblioteca.Data;

public class BibliotecaContext : DbContext
{
    public BibliotecaContext(DbContextOptions<BibliotecaContext> opts) : base(opts) { }

    public DbSet<Livro> Livros { get; set;}
    public DbSet<Editora> Editoras { get; set;}
    public DbSet<Periodico> Periodicos { get; set;}
    public DbSet<Aluno> Alunos { get; set;}
    public DbSet<Funcionario> Funcionarios { get; set;}
    public DbSet<Emprestimo> Emprestimos { get; set;}
    public DbSet<ItemEmprestimo> ItemEmprestimos { get; set;}
}