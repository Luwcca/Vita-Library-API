using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Data;

namespace WebApi_Biblioteca.Controllers;
[ApiController]
[Route("[controller]")]
public class MultasController : ControllerBase
{
    private BibliotecaContext _context;

    public MultasController(BibliotecaContext context)
    {
        _context = context;
    }

    [HttpPatch("{AlunoId}")]
    [AllowAnonymous]
    public IActionResult GerarMulta(int AlunoId, [FromBody] int multa)
    {
        var aluno = _context.Alunos.FirstOrDefault(a => a.AlunoId == AlunoId);
        if (aluno == null)
        {
            return NotFound("Aluno não encontrado");
        }

        aluno.Multas += multa;
        aluno.Checkbox = false;

        _context.SaveChanges();

        return Ok($"Registrada multa de R${multa} para o aluno de ID {AlunoId}");
    }

    [HttpPatch("{AlunoId}")]
    [AllowAnonymous]
    public IActionResult PagarMulta(int AlunoId, [FromBody] int valor)
    {
        var aluno = _context.Alunos.FirstOrDefault(a => a.AlunoId == AlunoId);
        if (aluno == null)
        {
            return NotFound("Aluno não encontrado");
        }

        aluno.Multas += valor;
        aluno.Checkbox = false;

        _context.SaveChanges();

        return Ok($"Pago o valor de R${valor} da multa, para o aluno de ID {AlunoId}.");
    }

}
