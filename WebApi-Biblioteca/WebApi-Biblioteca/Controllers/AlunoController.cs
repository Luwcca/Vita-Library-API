using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Data.Dtos.AlunoDtos;
using WebApi_Biblioteca.Data;
using WebApi_Biblioteca.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApi_Biblioteca.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class AlunoController : ControllerBase
{
    private BibliotecaContext _context;
    private IMapper _mapper;

    public AlunoController(BibliotecaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um Aluno ao banco de dados
    /// </summary>
    /// <param name="dto">Objeto com os campos necessários para criação de um Aluno</param>
    /// <returns>ActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    /// <response code="400">Caso preenchimento do formulário esteja incorreto</response>   
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public ActionResult<CreateAlunoDto> PostAluno([FromBody] CreateAlunoDto dto)
    {
        Aluno aluno = _mapper.Map<Aluno>(dto);
        try
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException.Message);
        }
        return CreatedAtAction(nameof(GetAluno), new { id = aluno.AlunoId }, aluno);

    }

    /// <summary>
    /// Relatório dos Alunos no banco de dados
    /// </summary>
    /// <returns>ActionResult</returns>
    /// <response code="200">Caso retorno seja feita com sucesso</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet]
    public ActionResult<IEnumerable<ReadAlunoDto>> GetAluno()
    {
        var alunos = _mapper.Map<List<ReadAlunoDto>>(_context.Alunos);
        return Ok(alunos);
    }

    /// <summary>
    /// Consulta um Aluno no banco de dados
    /// </summary>
    /// <param name="id">Id do aluno para consulta</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">Caso consulta seja feita com sucesso</response>
    /// <response code="400">Caso  Id de consulta seja inválido</response>
    /// <response code="404">Caso o Id de consulta  não seja encontrado na Banco de Dados</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id}")]
    public ActionResult<ReadAlunoDto> GetAlunoByID(int id)
    {
        if (id <= 0 || id == null)
        {
            return BadRequest("Id de Aluno inválido");
        }

        var aluno = _context.Alunos.Find(id);
        if (aluno == null)
        {
            return NotFound("Aluno não encontrado");
        }

        var alunodto = _mapper.Map<ReadAlunoDto>(aluno);

        return Ok(alunodto);
    }

    /// <summary>
    /// Atualiza o registro de um aluno do banco de dados
    /// </summary>
    /// <param name="id">Id do aluno para atualizar</param>
    /// /// <param name="dto">Objeto com os campos necessários para atualização de um Aluno</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">Caso registro seja atualizado com sucesso</response>
    /// <response code="400">Caso preenchimento do formulário esteja incorreto</response>
    /// <response code="404">Caso os Id não sejam encontrados na Base de Dados</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPut("{id}")]
    public ActionResult<UpdateAlunoDto> PutAluno(int id, [FromBody] UpdateAlunoDto dto)
    {
        var aluno = _context.Alunos.Find(id);
        if (aluno == null)
        {
            return NotFound("Aluno não encontrado");
        }
        try
        {
            _mapper.Map(dto, aluno);

            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException.Message);
        }

        return Ok("Informações do Aluno alterada");
    }

    /// <summary>
    /// Deleta um aluno do banco de dados
    /// </summary>
    /// <param name="id">Id do aluno para deletar</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">Caso registro seja deletado com sucesso</response>
    /// <response code="404">Caso o Id não seja encontrado na Base de Dados</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id}")]
    public ActionResult DeleteAluno(int id)
    {
        var aluno = _context.Alunos.Find(id);
        if (aluno == null)
        {
            return NotFound("Id de Aluno não encontrado");
        }
        _context.Alunos.Remove(aluno);
        _context.SaveChanges();

        return Ok("Aluno deletado");
    }
}
