﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi_Biblioteca.Data;

#nullable disable

namespace WebApi_Biblioteca.Migrations
{
    [DbContext(typeof(BibliotecaContext))]
    partial class BibliotecaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApi_Biblioteca.Models.Aluno", b =>
                {
                    b.Property<int>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlunoId"));

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CPF")
                        .HasColumnType("int");

                    b.Property<bool>("Checkbox")
                        .HasColumnType("bit");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Multas")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefone")
                        .HasColumnType("int");

                    b.Property<string>("UF")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlunoId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("WebApi_Biblioteca.Models.Editora", b =>
                {
                    b.Property<int>("EditoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EditoraId"));

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UF")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EditoraId");

                    b.ToTable("Editoras");
                });

            modelBuilder.Entity("WebApi_Biblioteca.Models.Emprestimo", b =>
                {
                    b.Property<int>("EmprestimoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmprestimoId"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Devolucao")
                        .HasColumnType("datetime2");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Hora")
                        .HasColumnType("datetime2");

                    b.HasKey("EmprestimoId");

                    b.HasIndex("AlunoId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Emprestimos");
                });

            modelBuilder.Entity("WebApi_Biblioteca.Models.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FuncionarioId"));

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CPF")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefone")
                        .HasColumnType("int");

                    b.Property<string>("UF")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FuncionarioId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("WebApi_Biblioteca.Models.ItemEmprestimo", b =>
                {
                    b.Property<int>("ItemEmprestimoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemEmprestimoId"));

                    b.Property<DateTime>("Devolucao")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmprestimoId")
                        .HasColumnType("int");

                    b.Property<int>("LivroId")
                        .HasColumnType("int");

                    b.Property<int>("PeriodicoId")
                        .HasColumnType("int");

                    b.HasKey("ItemEmprestimoId");

                    b.HasIndex("EmprestimoId")
                        .IsUnique();

                    b.HasIndex("LivroId")
                        .IsUnique();

                    b.HasIndex("PeriodicoId")
                        .IsUnique();

                    b.ToTable("ItemEmprestimos");
                });

            modelBuilder.Entity("WebApi_Biblioteca.Models.Livro", b =>
                {
                    b.Property<int>("LivroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LivroId"));

                    b.Property<string>("Assunto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Autor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EditoraId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<int?>("Tombo")
                        .HasColumnType("int");

                    b.HasKey("LivroId");

                    b.HasIndex("EditoraId");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("WebApi_Biblioteca.Models.Periodico", b =>
                {
                    b.Property<int>("PeriodicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PeriodicoId"));

                    b.Property<string>("Assunto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Autor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<int?>("Tombo")
                        .HasColumnType("int");

                    b.HasKey("PeriodicoId");

                    b.ToTable("Periodicos");
                });

            modelBuilder.Entity("WebApi_Biblioteca.Models.Emprestimo", b =>
                {
                    b.HasOne("WebApi_Biblioteca.Models.Aluno", "Aluno")
                        .WithMany("Emprestimos")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi_Biblioteca.Models.Funcionario", "Funcionario")
                        .WithMany("Emprestimos")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("WebApi_Biblioteca.Models.ItemEmprestimo", b =>
                {
                    b.HasOne("WebApi_Biblioteca.Models.Emprestimo", "Emprestimo")
                        .WithOne("ItemEmprestimo")
                        .HasForeignKey("WebApi_Biblioteca.Models.ItemEmprestimo", "EmprestimoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi_Biblioteca.Models.Livro", "Livro")
                        .WithOne("ItemEmprestimo")
                        .HasForeignKey("WebApi_Biblioteca.Models.ItemEmprestimo", "LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi_Biblioteca.Models.Periodico", "Periodico")
                        .WithOne("ItemEmprestimo")
                        .HasForeignKey("WebApi_Biblioteca.Models.ItemEmprestimo", "PeriodicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Emprestimo");

                    b.Navigation("Livro");

                    b.Navigation("Periodico");
                });

            modelBuilder.Entity("WebApi_Biblioteca.Models.Livro", b =>
                {
                    b.HasOne("WebApi_Biblioteca.Models.Editora", "Editora")
                        .WithMany("Livros")
                        .HasForeignKey("EditoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Editora");
                });

            modelBuilder.Entity("WebApi_Biblioteca.Models.Aluno", b =>
                {
                    b.Navigation("Emprestimos");
                });

            modelBuilder.Entity("WebApi_Biblioteca.Models.Editora", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("WebApi_Biblioteca.Models.Emprestimo", b =>
                {
                    b.Navigation("ItemEmprestimo")
                        .IsRequired();
                });

            modelBuilder.Entity("WebApi_Biblioteca.Models.Funcionario", b =>
                {
                    b.Navigation("Emprestimos");
                });

            modelBuilder.Entity("WebApi_Biblioteca.Models.Livro", b =>
                {
                    b.Navigation("ItemEmprestimo")
                        .IsRequired();
                });

            modelBuilder.Entity("WebApi_Biblioteca.Models.Periodico", b =>
                {
                    b.Navigation("ItemEmprestimo")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
