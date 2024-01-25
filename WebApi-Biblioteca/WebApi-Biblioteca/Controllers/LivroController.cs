using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Models;

namespace WebApi_Biblioteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        public static List<Livro> livros = new List<Livro>();

        [HttpGet]
        public IActionResult GetLivros()
        {
            return Ok(livros);
        }

        [HttpPost]
        public void PostLivro([FromBody]Livro livro)
        {
            livros.Add(livro);
            Console.WriteLine("Livro adicionado");
        }

        
    }
}
