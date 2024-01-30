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

    [HttpPost]
    public IActionResult PostAluno([FromBody] CreateAlunoDto dto)
    {
        Aluno aluno = _mapper.Map<Aluno>(dto);
        _context.Alunos.Add(aluno);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAluno), new { id = aluno.AlunoId }, aluno);

    }

    [HttpGet]
    public IEnumerable<ReadAlunoDto> GetAluno()
    {
        return _mapper.Map<List<ReadAlunoDto>>(_context.Alunos);
    }

    [HttpGet("{id}")]
    public IActionResult GetAlunoByID(int id)
    {
        var aluno = _context.Alunos.Find(id);
        if (aluno == null)
        {
            return NotFound();
        }

        var alunodto = _mapper.Map<ReadAlunoDto>(aluno);

        return Ok(alunodto);
    }

    [HttpPut("{id}")]
    public IActionResult PutAluno(int id, [FromBody] UpdateAlunoDto dto)
    {
        var aluno = _context.Alunos.Find(id);
        if (aluno == null)
        {
            return NotFound();
        }

        _mapper.Map(dto, aluno);

        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteAluno(int id)
    {
        var aluno = _context.Alunos.Find(id);
        if (aluno == null)
        {
            return NotFound();
        }
        _context.Alunos.Remove(aluno);
        _context.SaveChanges();
        return NoContent();
    }
}
