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
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult PostAluno([FromBody] CreateAlunoDto dto)
    {
        Aluno aluno = _mapper.Map<Aluno>(dto);
        _context.Alunos.Add(aluno);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAluno), new { id = aluno.AlunoId }, aluno);

    }

    /// <summary>
    /// Relatório dos Alunos no banco de dados
    /// </summary>
    /// <returns>IEnumerable</returns>
    /// <response code="200">Caso retorno seja feita com sucesso</response>
    [HttpGet]
    public IEnumerable<ReadAlunoDto> GetAluno()
    {
        return _mapper.Map<List<ReadAlunoDto>>(_context.Alunos);
    }

    /// <summary>
    /// Consulta um Aluno no banco de dados
    /// </summary>
    /// <param name="id">Id do aluno para consulta</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso consulta seja feita com sucesso</response>
    [HttpGet("{id}")]
    public IActionResult GetAlunoByID(int id)
    {
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
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso registro seja atualizado com sucesso</response>
    [HttpPut("{id}")]
    public IActionResult PutAluno(int id, [FromBody] UpdateAlunoDto dto)
    {
        var aluno = _context.Alunos.Find(id);
        if (aluno == null)
        {
            return NotFound("Aluno não encontrado");
        }

        _mapper.Map(dto, aluno);

        _context.SaveChanges();
        return Ok("Informações do Aluno alterada");
    }

    /// <summary>
    /// Deleta um aluno do banco de dados
    /// </summary>
    /// <param name="id">Id do aluno para deletar</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso registro seja deletado com sucesso</response>
    [HttpDelete("{id}")]
    public IActionResult DeleteAluno(int id)
    {
        var aluno = _context.Alunos.Find(id);
        if (aluno == null)
        {
            return NotFound("Aluno não encontrado");
        }
        _context.Alunos.Remove(aluno);
        _context.SaveChanges();
        
        return Ok("Aluno deletado");
    }
}
