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
    /// <returns>ActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    /// <response code="400">Caso preenchimento do formulário esteja incorreto</response>   
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public ActionResult<CreateEditoraDto> PostEditora([FromBody] CreateEditoraDto dto)
    {
        Editora editora = _mapper.Map<Editora>(dto);
        try
        {
            _context.Editoras.Add(editora);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException.Message);
        }
        return CreatedAtAction(nameof(GetEditora), new { id = editora.EditoraId }, editora);

    }

    /// <summary>
    /// Relatório das Editoras no banco de dados
    /// </summary>
    /// <returns>IEnumerable</returns>
    /// <response code="200">Caso retorno seja feita com sucesso</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet]
    public ActionResult<IEnumerable<ReadEditoraDto>> GetEditora()
    {
        var editoras = _mapper.Map<List<ReadEditoraDto>>(_context.Editoras);
        return Ok(editoras);
    }

    /// <summary>
    /// Consulta uma Editora no banco de dados
    /// </summary>
    /// <param name="id">Id da Editora para consulta</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">Caso consulta seja feita com sucesso</response>
    /// <response code="400">Caso  Id de consulta seja inválido</response>
    /// <response code="404">Caso o Id de consulta  não seja encontrado na Banco de Dados</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id}")]
    public ActionResult<ReadEditoraDto> GetEditoraByID(int id)
    {
        if (id <= 0 || id == null)
        {
            return BadRequest("Id de Editora inválido");
        }

        var editora = _context.Editoras.Find(id);
        if (editora == null)
        {
            return NotFound("Editora Não encontrada na Base de dados");
        }

        var editoradto = _mapper.Map<ReadEditoraDto>(editora);

        return Ok(editoradto);
    }

    /// <summary>
    /// Atualiza o registro de uma Editora no banco de dados
    /// </summary>
    /// <param name="id">Id da Editora para atualizar</param>
    /// <param name="dto">Objeto com os campos necessários para atualização de uma Editora</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">Caso registro seja atualizado com sucesso</response>
    /// <response code="400">Caso preenchimento do formulário esteja incorreto</response>
    /// <response code="404">Caso os Id não sejam encontrados na Base de Dados</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPut("{id}")]
    public ActionResult<UpdateEditoraDto> PutEditora(int id, [FromBody] UpdateEditoraDto dto)
    {
        var editora = _context.Editoras.Find(id);
        if (editora == null)
        {
            return NotFound("Id da Editora não encontrado na Base de Dados");
        }

        try
        {
            _mapper.Map(dto, editora);

            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException.Message);
        }

        return Ok("Livro Atualizado");
    }

    /// <summary>
    /// Deleta uma Editora do banco de dados
    /// </summary>
    /// <param name="id">Id da Editora para deletar</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">Caso registro seja deletado com sucesso</response>
    /// <response code="404">Caso os Id não seja encontrado na Base de Dados</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id}")]
    public ActionResult DeleteEditora(int id)
    {
        var editora = _context.Editoras.Find(id);
        if (editora == null)
        {
            return NotFound("Id de Editora não encontrado");
        }
        _context.Editoras.Remove(editora);
        _context.SaveChanges();
        return Ok("Editora deletada");
    }
}
