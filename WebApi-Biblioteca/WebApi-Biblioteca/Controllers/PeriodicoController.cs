using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Data;
using WebApi_Biblioteca.Data.Dtos.PeriodicoDtos;
using WebApi_Biblioteca.Models;

namespace WebApi_Biblioteca.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class PeriodicoController : ControllerBase
{
    private BibliotecaContext _context;
    private IMapper _mapper;

    public PeriodicoController(BibliotecaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }



    /// <summary>
    /// Adiciona um Periodico ao banco de dados
    /// </summary>
    /// <param name="periodicodto">Objeto com os campos necessários para criação de um Periodico</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult PostPeriodico([FromBody] CreatePeriodicoDto periodicodto)
    {
        Periodico periodico = _mapper.Map<Periodico>(periodicodto);
        _context.Periodicos.Add(periodico);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetPeriodicos), new { id = periodico.PeriodicoId }, periodico);

    }

    /// <summary>
    /// Relatório dos Periodicoss no banco de dados
    /// </summary>
    /// <returns>IEnumerable</returns>
    /// <response code="200">Caso retorno seja feita com sucesso</response>
    [HttpGet]
    public ActionResult<IEnumerable<ReadPeriodicoDto>> GetPeriodicos()
    {
        var periodicos = _mapper.Map<List<ReadPeriodicoDto>>(_context.Periodicos);
        return Ok(periodicos);
    }

    /// <summary>
    /// Consulta um Periodico no banco de dados
    /// </summary>
    /// <param name="id">Id do Periodico para consulta</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso consulta seja feita com sucesso</response>
    [HttpGet("{id}")]
    public IActionResult GetPeriodicosByID(int id)
    {
        var periodico = _context.Periodicos.Find(id);
        if (periodico == null)
        {
            return NotFound();
        }

        var periodicodto = _mapper.Map<ReadPeriodicoDto>(periodico);

        return Ok(periodicodto);
    }

    /// <summary>
    /// Atualiza o registro de um Periodico no banco de dados
    /// </summary>
    /// <param name="id">Id do Periodico para atualizar</param>
    /// <param name="dto">Objeto com os campos necessários para atualização de um Periodico</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso registro seja atualizado com sucesso</response>
    [HttpPut("{id}")]
    public IActionResult PutPeriodico(int id, [FromBody] UpdatePeriodicoDto dto)
    {
        var periodico = _context.Periodicos.Find(id);
        if (periodico == null)
        {
            return NotFound();
        }

        _mapper.Map(dto, periodico);

        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deleta um Periodico do banco de dados
    /// </summary>
    /// <param name="id">Id do Periodico para deletar</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso registro seja deletado com sucesso</response>
    [HttpDelete("{id}")]
    public IActionResult DeletePeriodico(int id)
    {
        var periodico = _context.Periodicos.Find(id);
        if (periodico == null)
        {
            return NotFound();
        }
        _context.Periodicos.Remove(periodico);
        _context.SaveChanges();
        return NoContent();
    }
}