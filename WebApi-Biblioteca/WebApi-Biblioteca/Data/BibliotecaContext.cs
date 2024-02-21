using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        builder
            .Entity<Livro>()
            .HasOne(e => e.Editora)
            .WithMany(e => e.Livros)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Entity<Livro>()
            .HasMany(e => e.ItemEmprestimo)
            .WithOne(e => e.Livro)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Entity<Periodico>()
            .HasMany(e => e.ItemEmprestimo)
            .WithOne(e => e.Periodico)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Funcionario>()
            .HasIndex(e => e.Login).IsUnique(true);
    }
}