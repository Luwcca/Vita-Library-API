using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Data;
using WebApi_Biblioteca.Data.Dtos.LivrosDtos;
using WebApi_Biblioteca.Models;

namespace WebApi_Biblioteca.Controllers;

[ApiController]
[Route("[controller]")]
public class LivroController : ControllerBase
{
    private BibliotecaContext _context;
    private IMapper _mapper;

    public LivroController(BibliotecaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    

    [HttpPost]
    public IActionResult PostLivro([FromBody] CreateLivroDto livrodto)
    {
        Livro livro = _mapper.Map<Livro>(livrodto);
        _context.Livros.Add(livro);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetLivros), new { id = livro.LivroId }, livro);

    }

    [HttpGet]
    public IEnumerable<ReadLivroDto> GetLivros()
    {
        return _mapper.Map<List<ReadLivroDto>>(_context.Livros);
    }

    [HttpGet("{id}")]
    public IActionResult GetLivrosByID(int id)
    {
        var livro = _context.Livros.Find(id);
        if (livro == null)
        {
            return NotFound();
        }

        var livrodto = _mapper.Map<ReadLivroDto>(livro);

        return Ok(livrodto);
    }
}