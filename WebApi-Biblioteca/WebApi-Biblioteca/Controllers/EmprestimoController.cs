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
[Authorize]
public class EmprestimoController : ControllerBase
{
    private BibliotecaContext _context;
    private IMapper _mapper;

    public EmprestimoController(BibliotecaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    /// <summary>
    /// Adiciona um Emprestimo ao Banco de Dados
    /// </summary>
    /// <param name="emprestimoDto">Objeto com os campos necessários para criação de um Emprestimo</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso inserção seja feita com sucesso</response>
    [HttpPost("Emprestimo")]
    public IActionResult PostEmprestimo([FromBody] PostEmprestimoDto emprestimoDto)
    {
        Emprestimo emprestimo = _mapper.Map<Emprestimo>(emprestimoDto);
        var service = new EmprestimoService();

        if (_context.Funcionarios.Find(emprestimo.FuncionarioId) == null)
            { return NotFound("Funcionario não encontrado"); }
        if (_context.Alunos.Find(emprestimo.AlunoId) == null) 
            { return NotFound("Aluno não encontrado"); }

        if (!service.ValidarEntrada(emprestimo))
            { return BadRequest("Escolha um livro ou um periodico para emprestimo"); }

        if(_context.Livros.Find(emprestimo.ItemEmprestimo.LivroId) == null & emprestimo.ItemEmprestimo.LivroId != null)
            { return NotFound("Livro não encontrado"); }

        if (_context.Periodicos.Find(emprestimo.ItemEmprestimo.PeriodicoId) == null & emprestimo.ItemEmprestimo.PeriodicoId != null)
        { return NotFound("Periodico não encontrado"); }

        if (!service.ValidarAluno(emprestimo, _context))
        { return BadRequest("Aluno não pode pegar emprestimo, pois está multado"); }

        if (!service.ChecarDisponibilidade(emprestimo.ItemEmprestimo.LivroId, emprestimo.ItemEmprestimo.PeriodicoId, _context))
        { return BadRequest("Item indisponível para emprestimo"); }


        service.RealizarEmprestimo(emprestimo, _context);


        return Ok($"Realizado emprestimo sob número {emprestimo.EmprestimoId}.\nData para devolução: {emprestimo.ItemEmprestimo.Devolucao}");
    }

    /// <summary>
    /// Atualiza o registro dos Emprestimo no banco de dados, devolvendo os items emprestados.
    /// </summary>
    /// <param name="Id">Id do Emprestimo para atualizar</param>
    /// <param name="dto">Objeto com os campos necessários para atualização de um Emprestimo</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso registro seja atualizado com sucesso</response>
    [HttpPut("Devolução{Id}")]
    public IActionResult PutDevolucao(int Id, [FromBody] DevolucaoDto dto)
    {
        var devolucao = _context.Emprestimos.Find(Id);
        if (devolucao == null)
        {
            return NotFound("Emprestimo não encontrado");
        }
        if(devolucao.Devolucao != null)
        {
            return BadRequest("Devolução já realizada");
        }

        devolucao.Devolucao = dto.Devolucao;

        var service = new EmprestimoService();

        service.Devolucao(devolucao, _context);

        return Ok($"Emprestimo nº {devolucao.EmprestimoId} devolvido as {devolucao.Devolucao}");
    }

    /// <summary>
    /// Relatório dos Emprestimos no banco de dados
    /// </summary>
    /// <returns>IEnumerable</returns>
    /// <response code="200">Caso retorno seja feita com sucesso</response>
    [HttpGet]
    public ICollection<GetItemEmprestimosDto> GetEmprestimos()
    {
        return _mapper.Map<List<GetItemEmprestimosDto>>(_context.ItemEmprestimos.ToList());
    }


}
