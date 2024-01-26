using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Data;
using WebApi_Biblioteca.Data.Dtos.EditoraDtos;
using WebApi_Biblioteca.Models;

namespace WebApi_Biblioteca.Controllers;

[ApiController]
[Route("[controller]")]
public class EditoraController : ControllerBase
{
    private BibliotecaContext _context;
    private IMapper _mapper;

    public EditoraController(BibliotecaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult PostEditora([FromBody] CreateEditoraDto dto)
    {
        Editora editora = _mapper.Map<Editora>(dto);
        _context.Editoras.Add(editora);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetEditora), new { id = editora.EditoraId }, editora);

    }

    [HttpGet]
    public IEnumerable<ReadEditoraDto> GetEditora()
    {
        return _mapper.Map<List<ReadEditoraDto>>(_context.Editoras);
    }

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
}
