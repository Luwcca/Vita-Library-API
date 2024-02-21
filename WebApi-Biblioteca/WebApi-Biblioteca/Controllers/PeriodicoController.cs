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
    /// <returns>ActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    /// <response code="400">Caso preenchimento do formulário esteja incorreto</response>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public ActionResult<CreatePeriodicoDto> PostPeriodico([FromBody] CreatePeriodicoDto periodicodto)
    {
        Periodico periodico = _mapper.Map<Periodico>(periodicodto);

        try
        {

            _context.Periodicos.Add(periodico);
            _context.SaveChanges();

        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException.Message);
        }

        return CreatedAtAction(nameof(GetPeriodicos), new { id = periodico.PeriodicoId }, periodico);

    }

    /// <summary>
    /// Relatório dos Periodicoss no banco de dados
    /// </summary>
    /// <returns>ActionResult</returns>
    /// <response code="200">Caso retorno seja feita com sucesso</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
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
    /// <returns>ActionResult</returns>
    /// <response code="200">Caso consulta seja feita com sucesso</response>
    /// <response code="400">Caso  Id de consulta seja inválido</response>
    /// <response code="404">Caso o Id de consulta  não seja encontrado na Banco de Dados</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id}")]
    public ActionResult<ReadPeriodicoDto> GetPeriodicosByID(int id)
    {
        if (id <= 0 || id == null)
        {
            return BadRequest("Id de Periodico inválido");
        }

        var periodico = _context.Periodicos.Find(id);
        if (periodico == null)
        {
            return NotFound("Periodico não encontrado na Base de dados");
        }

        var periodicodto = _mapper.Map<ReadPeriodicoDto>(periodico);

        return Ok(periodicodto);
    }

    /// <summary>
    /// Atualiza o registro de um Periodico no banco de dados
    /// </summary>
    /// <param name="id">Id do Periodico para atualizar</param>
    /// <param name="dto">Objeto com os campos necessários para atualização de um Periodico</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">Caso registro seja atualizado com sucesso</response>
    /// <response code="400">Caso preenchimento do formulário esteja incorreto</response>
    /// <response code="404">Caso o Id não seja encontrado na Base de Dados</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPut("{id}")]
    public ActionResult<UpdatePeriodicoDto> PutPeriodico(int id, [FromBody] UpdatePeriodicoDto dto)
    {
        var periodico = _context.Periodicos.Find(id);
        if (periodico == null)
        {
            return NotFound("Periodico não econtrado na Base de dados");
        }

        try
        {
            _mapper.Map(dto, periodico);

            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException.Message);
        }

        return Ok("Periodico atualizado");
    }

    /// <summary>
    /// Deleta um Periodico do banco de dados
    /// </summary>
    /// <param name="id">Id do Periodico para deletar</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">Caso registro seja deletado com sucesso</response>
    /// <response code="404">Caso Id do periodico não encontrado no Base de dados</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{id}")]
    public ActionResult DeletePeriodico(int id)
    {
        var periodico = _context.Periodicos.Find(id);
        if (periodico == null)
        {
            return NotFound("Id de periodico não encontrado no Base de dados");
        }
        _context.Periodicos.Remove(periodico);
        _context.SaveChanges();
        return Ok("Periodico deletado");
    }
}