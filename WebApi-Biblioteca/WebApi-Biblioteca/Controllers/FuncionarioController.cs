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


    public FuncionarioController(BibliotecaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um Funcionario ao banco de dados
    /// </summary>
    /// <param name="dto">Objeto com os campos necessários para criação de um Funcionario</param>
    /// <returns>ActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    /// <response code="400">Caso preenchimento do formulário esteja incorreto</response>   
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [AllowAnonymous]
    [HttpPost("RegisterFuncionario")]
    public ActionResult<CreateFuncionarioDto> RegisterFuncionario([FromBody] CreateFuncionarioDto dto)
    {
        var funcionario = _mapper.Map<Funcionario>(dto);

        try
        {
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException.Message);
        }
        return CreatedAtAction(nameof(GetFuncionario), new { id = funcionario.FuncionarioId }, funcionario);
    }


    /// <summary>
    /// Realiza o Log In de um Funcionario atrelado ao banco de dados
    /// </summary>
    /// <param name="dto">Objeto com os campos necessários para realizar o Log In</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">Caso Login seja feita com sucesso</response>
    /// <response code="400">Caso preenchimento do formulário para Login incorreto</response>
    /// <response code="401">Caso senha esteja incorreta</response>
    /// <response code="404">Caso Login não seja encontrado na base de dados</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost("LogInFuncionario")]
    [AllowAnonymous]
    public ActionResult<LoginFuncionarioDto> LogInFuncionario([FromBody] LoginFuncionarioDto dto)
    {
        if (dto.Login.IsNullOrEmpty() || dto.Senha.IsNullOrEmpty())
        {
            return BadRequest("Preencha todos os campos para realizar o Login");
        }

        var user = _context.Funcionarios.Where(x => x.Login == dto.Login).FirstOrDefault();

        if (user == null)
        {
            return NotFound("Usuario não encontrado");
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


        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("VivoVita-Library_WebApi$#@!2024¨%$#@!"));

        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddMinutes(30);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: "WebApi",
            audience: "WebApi",
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
            );

        return Ok($"Token para acesso: {new JwtSecurityTokenHandler().WriteToken(token)}");
    }

    /// <summary>
    /// Relatório dos Funcionarios no banco de dados
    /// </summary>
    /// <returns>ActionResult</returns>
    /// <response code="200">Caso retorno seja feita com sucesso</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet]
    public ActionResult<IEnumerable<ReadFuncionarioDto>> GetFuncionario()
    {
        var funcionarios = _mapper.Map<List<ReadFuncionarioDto>>(_context.Funcionarios);
        return Ok(funcionarios);
    }

    /// <summary>
    /// Consulta um Funcionario no banco de dados
    /// </summary>
    /// <param name="id">Id do funcionario para consulta</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">Caso consulta seja feita com sucesso</response>
    /// <response code="400">Caso  Id de consulta seja inválido</response>
    /// <response code="404">Caso o Id de consulta  não seja encontrado na Banco de Dados</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id}")]
    public ActionResult<ReadFuncionarioDto> GetFuncionarioByID(int id)
    {
        if (id <= 0 || id == null)
        {
            return BadRequest("Id de Funcionario inválido");
        }

        var funcionario = _context.Funcionarios.Find(id);
        if (funcionario == null)
        {
            return NotFound("Funcionario não encontrado");
        }

        var funcionariodto = _mapper.Map<ReadFuncionarioDto>(funcionario);

        return Ok(funcionariodto);
    }

    /// <summary>
    /// Atualiza o registro de um funcionario do banco de dados
    /// </summary>
    /// <param name="id">Id do funcionario para atualizar</param>
    /// /// <param name="dto">Objeto com os campos necessários para atualização de um Funcionario</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">Caso registro seja atualizado com sucesso</response>
    /// <response code="400">Caso formulário para atualização esteja incorreto</response>
    /// <response code="404">Caso o Id de funcionario  não seja encontrado na Banco de Dados</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPut("{id}")]
    public ActionResult<UpdateFuncionarioDto> PutFuncionario(int id, [FromBody] UpdateFuncionarioDto dto)
    {
        var funcionario = _context.Funcionarios.Find(id);
        if (funcionario == null)
        {
            return NotFound("Funcionario não encontrado");
        }

        try
        {
            _mapper.Map(dto, funcionario);

            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException.Message);
        }

        return Ok("Informações do Funcionario alterada");
    }

    /// <summary>
    /// Deleta um Funcionario do banco de dados
    /// </summary>
    /// <param name="id">Id do Funcionario para deletar</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">Caso registro seja deletado com sucesso</response>
    /// <response code="404">Caso o Id não seja encontrado na Base de Dados</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id}")]
    public ActionResult DeleteFuncionario(int id)
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
