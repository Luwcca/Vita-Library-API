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

    [AllowAnonymous]
    [HttpPost("RegisterFuncionario")]
    public IActionResult RegisterFuncionario([FromBody] CreateFuncionarioDto dto)
    {
        var funcionario = _mapper.Map<Funcionario>(dto);
        _context.Funcionarios.Add(funcionario);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetFuncionario), new { id = funcionario.FuncionarioId }, funcionario);
    }

    [AllowAnonymous]
    [HttpPost("LogInFuncionario")]
    public IActionResult LogInFuncionario([FromBody] LoginFuncionarioDto dto)
    {

        var user = _context.Funcionarios.Where(x => x.Login == dto.Login).FirstOrDefault();
        if (user == null)
        {
            return NotFound();
        }

        if (!user.Senha.Equals(dto.Senha))
        {
            return Unauthorized();
        }

        var claims = new []
        {
            new Claim("login", dto.Login),
            new Claim(JwtRegisteredClaimNames.Jti, user.FuncionarioId.ToString() )
        };

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));

        var credentials = new SigningCredentials(privateKey,SecurityAlgorithms.HmacSha256);

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

    [HttpGet]
    public IEnumerable<ReadFuncionarioDto> GetFuncionario()
    {
        return _mapper.Map<List<ReadFuncionarioDto>>(_context.Funcionarios);
    }

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
}
