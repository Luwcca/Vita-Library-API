using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi_Biblioteca.Data;
using WebApi_Biblioteca.Data.Dtos.EmprestimoDtos;
using WebApi_Biblioteca.Models;
using WebApi_Biblioteca.Services;

namespace WebApi_Biblioteca.Controllers;

[ApiController]
[Route("[controller]")]
public class EmprestimoController : ControllerBase
{
    private BibliotecaContext _context;
    private IMapper _mapper;

    public EmprestimoController(BibliotecaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost("Emprestimo")]
    [AllowAnonymous]
    public IActionResult PostEmprestimo([FromBody] PostEmprestimoDto emprestimoDto)
    {
        Emprestimo emprestimo = _mapper.Map<Emprestimo>(emprestimoDto);
        var service = new EmprestimoService();

        if (!service.ValidarEntrada(emprestimo))
        { return BadRequest("Escolha um livro ou um periodico para emprestimo"); }

        if (!service.ChecarDisponibilidade(emprestimo.ItemEmprestimo.LivroId, emprestimo.ItemEmprestimo.PeriodicoId, _context))
        { return BadRequest("Item indisponível para emprestimo"); }


        service.RealizarEmprestimo(emprestimo, _context);


        return Ok($"Realizado emprestimo sob número {emprestimo.EmprestimoId}");
    }

    [HttpPut("Devolução{Id}")]
    [AllowAnonymous]
    public IActionResult PutDevolucao(int Id, [FromBody] DevolucaoDto dto)
    {
        var devolucao = _context.Emprestimos.Find(Id);
        if (devolucao == null)
        {
            return NotFound("Emprestimo não encontrado");
        }

        devolucao.Devolucao = dto.Devolucao;

        var service = new EmprestimoService();

        service.Devolucao(devolucao, _context);

        return Ok($"Emprestimo nº {devolucao.EmprestimoId} devolvido as {devolucao.Devolucao}");
    }

    [HttpGet]
    [AllowAnonymous]
    public ICollection<GetEmprestimosDto> GetEmprestimos()
    {
        return _mapper.Map<List<GetEmprestimosDto>>(_context.Emprestimos);
    }
}
