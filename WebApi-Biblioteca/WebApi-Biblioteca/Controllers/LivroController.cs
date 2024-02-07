using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
    /// <response code="400">Caso preenchimento do formulário esteja incorreto</response>
    /// <response code="404">Caso Id da Editora não seja encontrado no Banco de Dados</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<CreateLivroDto> PostLivro([FromBody] CreateLivroDto livrodto)
    {
        if (livrodto.Assunto.IsNullOrEmpty() || livrodto.Autor.IsNullOrEmpty() || livrodto.Status == null
            || livrodto.Nome.IsNullOrEmpty() || livrodto.Tombo == null || livrodto.EditoraId == null)
        {
            return BadRequest("Todos os campos do formulário precisam ser preenchidos");
        }

        if(_context.Editoras.Find(livrodto.EditoraId) == null)
        {
            return NotFound("Id de Editora não encontrado na Base de Dados");
        }

        var livro = _mapper.Map<Livro>(livrodto);
        _context.Livros.Add(livro);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetLivros), new { id = livro.LivroId }, livro);

    }

    /// <summary>
    /// Relatório dos Livros no banco de dados
    /// </summary>
    /// <returns>IEnumerable</returns>
    /// <response code="200">Caso retorno seja feita com sucesso</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet]
    public ActionResult<IEnumerable<ReadLivroDto>> GetLivros()
    {
        var livros = _mapper.Map<IEnumerable<ReadLivroDto>>(_context.Livros);
        return Ok(livros);
    }

    /// <summary>
    /// Consulta um Livro no banco de dados
    /// </summary>
    /// <param name="id">Id do Livro para consulta</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso consulta seja feita com sucesso</response>
    /// <response code="400">Caso  Id de consulta seja inválido</response>
    /// <response code="404">Caso o Id de consulta  não seja encontrado na Banco de Dados</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id}")]
    public ActionResult<ReadLivroDto> GetLivrosByID(int id)
    {
        if (id <= 0 || id == null)
        {
            return BadRequest("Id de Livro inválido");
        }

        var livro = _context.Livros.Find(id);
        if (livro == null)
        {
            return NotFound("Livro não encontrado");
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
    /// <response code="400">Caso preenchimento do formulário esteja incorreto</response>
    /// <response code="404">Caso os Ids não sejam encontrados na Base de Dados</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPut("{id}")]
    public ActionResult<UpdateLivroDto> PutLivro(int id, [FromBody] UpdateLivroDto livrodto)
    {
        var livro = _context.Livros.Find(id);
        if (livro == null)
        {
            return NotFound("Id de livro não encontrado no Base de dados");
        }

        if (livrodto.Assunto.IsNullOrEmpty() || livrodto.Autor.IsNullOrEmpty() || livrodto.Status == null
            || livrodto.Nome.IsNullOrEmpty() || livrodto.Tombo == null || livrodto.EditoraId == null)
        {
            return BadRequest("Todos os campos do formulário precisam ser preenchidos");
        }

        if (_context.Editoras.Find(livrodto.EditoraId) == null)
        {
            return NotFound("Id de Editora não encontrado na Base de Dados");
        }

        _mapper.Map(livrodto, livro);

        _context.SaveChanges();
        return Ok("Livro atualizado");
    }

    /// <summary>
    /// Deleta um Livro do banco de dados
    /// </summary>
    /// <param name="id">Id do Livro para deletar</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso registro seja deletado com sucesso</response>
    /// <response code="404">Caso Id de livro não encontrado no Base de dados</response>
    [HttpDelete("{id}")]
    public ActionResult DeleteLivro(int id)
    {
        var livro = _context.Livros.Find(id);
        if (livro == null)
        {
            return NotFound("Id de livro não encontrado no Base de dados");
        }
        _context.Livros.Remove(livro);
        _context.SaveChanges();
        return Ok("Livro Deletado");
    }

}