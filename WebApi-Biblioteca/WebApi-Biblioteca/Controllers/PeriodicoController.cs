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



    [HttpPost]
    
    public IActionResult PostPeriodico([FromBody] CreatePeriodicoDto periodicodto)
    {
        Periodico periodico = _mapper.Map<Periodico>(periodicodto);
        _context.Periodicos.Add(periodico);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetPeriodicos), new { id = periodico.PeriodicoId }, periodico);

    }

    [HttpGet]
    public IEnumerable<ReadPeriodicoDto> GetPeriodicos()
    {
        return _mapper.Map<List<ReadPeriodicoDto>>(_context.Periodicos);
    }

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