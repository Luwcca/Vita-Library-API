using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Data;
using WebApi_Biblioteca.Data.Dtos.EditoraDtos;
using WebApi_Biblioteca.Models;

namespace WebApi_Biblioteca.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class EditoraController : ControllerBase
{
    private BibliotecaContext _context;
    private IMapper _mapper;

    public EditoraController(BibliotecaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona uma Editora ao banco de dados
    /// </summary>
    /// <param name="dto">Objeto com os campos necessários para criação de uma Editora</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult PostEditora([FromBody] CreateEditoraDto dto)
    {
        Editora editora = _mapper.Map<Editora>(dto);
        _context.Editoras.Add(editora);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetEditora), new { id = editora.EditoraId }, editora);

    }

    /// <summary>
    /// Relatório das Editoras no banco de dados
    /// </summary>
    /// <returns>IEnumerable</returns>
    /// <response code="200">Caso retorno seja feita com sucesso</response>
    [HttpGet]
    public IEnumerable<ReadEditoraDto> GetEditora()
    {
        return _mapper.Map<List<ReadEditoraDto>>(_context.Editoras);
    }

    /// <summary>
    /// Consulta uma Editora no banco de dados
    /// </summary>
    /// <param name="id">Id da Editora para consulta</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso consulta seja feita com sucesso</response>
    [HttpGet("{id}")]
    public IActionResult GetEditoraByID(int id)
    {
        var editora = _context.Editoras.Find(id);
        if (editora == null)
        {
            return NotFound();
        }

        var editoradto = _mapper.Map<ReadEditoraDto>(editora);

        return Ok(editoradto);
    }

    /// <summary>
    /// Atualiza o registro de uma Editora no banco de dados
    /// </summary>
    /// <param name="id">Id da Editora para atualizar</param>
    /// <param name="dto">Objeto com os campos necessários para atualização de uma Editora</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso registro seja atualizado com sucesso</response>
    [HttpPut("{id}")]
    public IActionResult PutEditora(int id, [FromBody] UpdateEditoraDto dto)
    {
        var editora = _context.Editoras.Find(id);
        if (editora == null)
        {
            return NotFound();
        }

        _mapper.Map(dto, editora);

        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deleta uma Editora do banco de dados
    /// </summary>
    /// <param name="id">Id da Editora para deletar</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso registro seja deletado com sucesso</response>
    [HttpDelete("{id}")]
    public IActionResult DeleteEditora(int id)
    {
        var editora = _context.Editoras.Find(id);
        if (editora == null)
        {
            return NotFound();
        }
        _context.Editoras.Remove(editora);
        _context.SaveChanges();
        return NoContent();
    }
}
