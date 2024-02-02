using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Data;
using WebApi_Biblioteca.Data.Dtos.LivrosDtos;
using WebApi_Biblioteca.Models;

namespace WebApi_Biblioteca.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class LivroController : ControllerBase
{
    private BibliotecaContext _context;
    private IMapper _mapper;

    public LivroController(BibliotecaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    /// <summary>
    /// Adiciona um Livro ao banco de dados
    /// </summary>
    /// <param name="livrodto">Objeto com os campos necessários para criação de um Livro</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult PostLivro([FromBody] CreateLivroDto livrodto)
    {
        Livro livro = _mapper.Map<Livro>(livrodto);
        _context.Livros.Add(livro);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetLivros), new { id = livro.LivroId }, livro);

    }

    /// <summary>
    /// Relatório dos Livros no banco de dados
    /// </summary>
    /// <returns>IEnumerable</returns>
    /// <response code="200">Caso retorno seja feita com sucesso</response>
    [HttpGet]
    public IEnumerable<ReadLivroDto> GetLivros()
    {
        return _mapper.Map<List<ReadLivroDto>>(_context.Livros);
    }

    /// <summary>
    /// Consulta um Livro no banco de dados
    /// </summary>
    /// <param name="id">Id do Livro para consulta</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso consulta seja feita com sucesso</response>
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

    /// <summary>
    /// Atualiza o registro de um Livro no banco de dados
    /// </summary>
    /// <param name="id">Id do Livro para atualizar</param>
    /// <param name="dto">Objeto com os campos necessários para atualização de um Livro</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso registro seja atualizado com sucesso</response>
    [HttpPut("{id}")]
    public IActionResult PutLivro(int id, [FromBody] UpdateLivroDto dto)
    {
        var livro = _context.Livros.Find(id);
        if (livro == null)
        {
            return NotFound();
        }

        _mapper.Map(dto, livro);

        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deleta um Livro do banco de dados
    /// </summary>
    /// <param name="id">Id do Livro para deletar</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso registro seja deletado com sucesso</response>
    [HttpDelete("{id}")]
    public IActionResult DeleteLivro(int id)
    {
        var livro = _context.Livros.Find(id);
        if (livro == null)
        {
            return NotFound();
        }
        _context.Livros.Remove(livro);
        _context.SaveChanges();
        return NoContent();
    }

}