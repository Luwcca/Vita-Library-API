using Microsoft.EntityFrameworkCore;
using WebApi_Biblioteca.Models;

namespace WebApi_Biblioteca.Data
{
    public class LivroContext: DbContext
    {
        public LivroContext(DbContextOptions<LivroContext> opts) : base(opts) { }
        
        DbSet<Livro> Livros { get; set; }
    }
}
