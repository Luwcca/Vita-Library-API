using WebApi_Biblioteca.Data;
using WebApi_Biblioteca.Models;

namespace WebApi_Biblioteca.Services;

public class EmprestimoService
{
    public bool ValidarEntrada(Emprestimo emprestimo)
    {

        if (emprestimo.ItemEmprestimo.LivroId == 0)
        {
            emprestimo.ItemEmprestimo.LivroId = null;
        }

        if (emprestimo.ItemEmprestimo.PeriodicoId == 0)
        {
            emprestimo.ItemEmprestimo.PeriodicoId = null;
        }

        if ((emprestimo.ItemEmprestimo.LivroId == null & emprestimo.ItemEmprestimo.PeriodicoId == null)
            | (emprestimo.ItemEmprestimo.LivroId != null & emprestimo.ItemEmprestimo.PeriodicoId != null))

        {
            return false;
        }
        return true;
    }
    public bool ChecarDisponibilidade(int? livroId, int? periodicoId, BibliotecaContext context)
    {
        if (livroId != null)
        {

            if((bool)context.Livros.Find(livroId).Status)
            {
                context.Livros.Find(livroId).Status = false;
                return true;
            }
        }

        if (periodicoId != null)
        {
            if ((bool)context.Periodicos.Find(periodicoId).Status)
            {
                context.Periodicos.Find(periodicoId).Status = false;
                return true;
            }
        }

        return false;
    }

    public void RealizarEmprestimo(Emprestimo emprestimo, BibliotecaContext _context)
    {
        emprestimo.ItemEmprestimo.Devolucao = emprestimo.Hora.AddDays(5);
        _context.Emprestimos.Add(emprestimo);
        _context.SaveChanges();
    }

    public void Devolucao(Emprestimo devolucao, BibliotecaContext _context)
    {
        var itemDevolucao = _context.ItemEmprestimos.FirstOrDefault(item => item.EmprestimoId == devolucao.EmprestimoId);
        var livroId = itemDevolucao.LivroId ;
        var periodicoId = itemDevolucao.PeriodicoId;

        if(livroId != null)
        {
            _context.Livros.Find(livroId).Status = true;
        }

        if(periodicoId != null)
        {
            _context.Periodicos.Find(periodicoId).Status = true;
        }

        _context.SaveChanges();
    }

    internal bool ValidarAluno(Emprestimo emprestimo, BibliotecaContext _context)
    {
        if (!_context.Alunos.FirstOrDefault(x => x.AlunoId == emprestimo.AlunoId).Checkbox)
        {
            return false;
        }
        return true;
    }
}
