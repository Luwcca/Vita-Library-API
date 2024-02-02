using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi_Biblioteca.Data;
using WebApi_Biblioteca.Data.Dtos.FuncionarioDtos;
using WebApi_Biblioteca.Models;

namespace WebApi_Biblioteca.Controllers;


[ApiController]
[Route("[controller]")]
[Authorize]
public class FuncionarioController : ControllerBase
{
    private BibliotecaContext _context;
    private IMapper _mapper;
    private IConfiguration _config;


    public FuncionarioController(BibliotecaContext context, IMapper mapper, IConfiguration configuration)
    {
        _context = context;
        _mapper = mapper;
        _config = configuration;
    }

    /// <summary>
    /// Adiciona um Funcionario ao banco de dados
    /// </summary>
    /// <param name="dto">Objeto com os campos necessários para criação de um Funcionario</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    
    [ProducesResponseType(StatusCodes.Status201Created)]
    [AllowAnonymous]
    [HttpPost("RegisterFuncionario")]
    public IActionResult RegisterFuncionario([FromBody] CreateFuncionarioDto dto)
    {
        var funcionario = _mapper.Map<Funcionario>(dto);
        _context.Funcionarios.Add(funcionario);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetFuncionario), new { id = funcionario.FuncionarioId }, funcionario);
    }


    /// <summary>
    /// Realiza o Log In de um Funcionario atrelado ao banco de dados
    /// </summary>
    /// <param name="dto">Objeto com os campos necessários para realizar o Log In</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso Log In seja feita com sucesso</response>
    [HttpPost("LogInFuncionario")]
    [AllowAnonymous]
    public IActionResult LogInFuncionario([FromBody] LoginFuncionarioDto dto)
    {

        var user = _context.Funcionarios.Where(x => x.Login == dto.Login).FirstOrDefault();
        if (user == null)
        {
            return NotFound();
        }

        if (!user.Senha.Equals(dto.Senha))
        {
            return Unauthorized("Senha incorreta");
        }

        var claims = new[]
        {
            new Claim("login", dto.Login),
            new Claim(JwtRegisteredClaimNames.Jti, user.FuncionarioId.ToString() )
        };

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));

        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddMinutes(30);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
            );

        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
    }

    /// <summary>
    /// Relatório dos Funcionarios no banco de dados
    /// </summary>
    /// <returns>IEnumerable</returns>
    /// <response code="200">Caso retorno seja feita com sucesso</response>
    [HttpGet]
    public IEnumerable<ReadFuncionarioDto> GetFuncionario()
    {
        return _mapper.Map<List<ReadFuncionarioDto>>(_context.Funcionarios);
    }

    /// <summary>
    /// Consulta um Funcionario no banco de dados
    /// </summary>
    /// <param name="id">Id do funcionario para consulta</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso consulta seja feita com sucesso</response>
    [HttpGet("{id}")]
    public IActionResult GetFuncionarioByID(int id)
    {
        var funcionario = _context.Funcionarios.Find(id);
        if (funcionario == null)
        {
            return NotFound();
        }

        var funcionariodto = _mapper.Map<ReadFuncionarioDto>(funcionario);

        return Ok(funcionariodto);
    }

    /// <summary>
    /// Atualiza o registro de um funcionario do banco de dados
    /// </summary>
    /// <param name="id">Id do funcionario para atualizar</param>
    /// /// <param name="dto">Objeto com os campos necessários para atualização de um Funcionario</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso registro seja atualizado com sucesso</response>
    [HttpPut("{id}")]
    public IActionResult PutFuncionario(int id, [FromBody] UpdateFuncionarioDto dto)
    {
        var funcionario = _context.Funcionarios.Find(id);
        if (funcionario == null)
        {
            return NotFound("Funcionario não encontrado");
        }

        _mapper.Map(dto, funcionario);

        _context.SaveChanges();
        return Ok("Informações do Funcionario alterada");
    }

    /// <summary>
    /// Deleta um Funcionario do banco de dados
    /// </summary>
    /// <param name="id">Id do Funcionario para deletar</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso registro seja deletado com sucesso</response>
    [HttpDelete("{id}")]
    public IActionResult DeleteFuncionario(int id)
    {
        var funcionario = _context.Funcionarios.Find(id);
        if (funcionario == null)
        {
            return NotFound("Funcionario não encontrado");
        }
        _context.Funcionarios.Remove(funcionario);
        _context.SaveChanges();

        return Ok("Funcionario deletado");
    }
}
