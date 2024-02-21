using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Data;

namespace WebApi_Biblioteca.Controllers;
[ApiController]
[Route("[controller]")]
[Authorize]
public class MultasController : ControllerBase
{
    private BibliotecaContext _context;

    public MultasController(BibliotecaContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gera uma multa ao Aluno e atualiza o banco de dados
    /// </summary>
    /// <param name="AlunoId">Id do Aluno para Gerar a Multa</param>
    /// <param name="multa">Valor da Multa</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">Caso Multa seja gerada com sucesso</response>
    /// <response code="404">Caso Id não seja encontrado</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPatch("Gerar Multa{AlunoId}")]
    public ActionResult GerarMulta(int AlunoId, [FromBody] int multa)
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

    /// <summary>
    /// Paga uma multa de um Aluno e atualiza o banco de dados
    /// </summary>
    /// <param name="AlunoId">Id do Aluno para Pagar a Multa</param>
    /// <param name="valor">Valor para ser debitado da Multa</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">Caso Multa seja paga com sucesso</response>
    /// <response code="404">Caso Id não seja encontrado</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPatch("Pagar Multa{AlunoId}")]
    public ActionResult PagarMulta(int AlunoId, [FromBody] int valor)
    {
        var aluno = _context.Alunos.FirstOrDefault(a => a.AlunoId == AlunoId);
        if (aluno == null)
        {
            return NotFound("Aluno não encontrado");
        }

        aluno.Multas -= valor;
        
        if(aluno.Multas == 0)
        {
            aluno.Checkbox = true;
        }

        _context.SaveChanges();

        return Ok($"Pago o valor de R${valor} da multa, para o aluno de ID {AlunoId}.");
    }

}
