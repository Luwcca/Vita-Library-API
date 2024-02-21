using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Biblioteca.Controllers;
using WebApi_Biblioteca.Data.Dtos.FuncionarioDtos;

namespace WebApi_Biblioteca_Tests.UnitTest.FuncionarioUnitTest;

public class PostFuncionarioUnitTest : IClassFixture<FuncionarioUnitTestController>
{
    private readonly FuncionarioController _controller;

    public PostFuncionarioUnitTest(FuncionarioUnitTestController controller)
    {
        _controller = new FuncionarioController(controller.context, controller.mapper);
    }

    [Fact]
    public void Post_RegisterFuncionario_CreatedAtAction_Result()
    {
        var funcionariodto = new CreateFuncionarioDto
        {
            Nome = "Funcionario",
            CPF = 1234567891,
            Rua = "Rua",
            Bairro = "Bairro",
            Cidade = "Cidade",
            UF = "SP",
            Telefone = 1234151234,
            Login = "login2",
            Senha = "senha" 
        };

        var data = _controller.RegisterFuncionario(funcionariodto);

        var result = data.Result.Should().BeOfType<CreatedAtActionResult>();
        result.Subject.StatusCode.Should().Be(201);
    }



    [Fact]
    public void Post_ResgisterFuncionario_BadRequest_Result()
    {
        CreateFuncionarioDto funcionariodto = null;

        var data = _controller.RegisterFuncionario(funcionariodto);

        var result = data.Result.Should().BeOfType<BadRequestObjectResult>();
        result.Subject.StatusCode.Should().Be(400);
    }


    [Fact]
    public void Post_LogInFuncionario_Ok_Result()
    {
        var funcionariodto = new LoginFuncionarioDto
        {
            Login = "login",
            Senha = "senha"
        };

        var data = _controller.LogInFuncionario(funcionariodto);

        var result = data.Result.Should().BeOfType<OkObjectResult>();
        result.Subject.StatusCode.Should().Be(200);
    }

    [Fact]
    public void Post_LogInFuncionario_BadRequest_Result()
    {
        var funcionariodto = new LoginFuncionarioDto
        {
            Login = "",
            Senha = ""
        };

        var data = _controller.LogInFuncionario(funcionariodto);

        var result = data.Result.Should().BeOfType<BadRequestObjectResult>();
        result.Subject.StatusCode.Should().Be(400);
    }

    [Fact]
    public void Post_LogInFuncionario_NotFound_Result()
    {
        var funcionariodto = new LoginFuncionarioDto
        {
            Login = "Usuario",
            Senha = "senha"
        };

        var data = _controller.LogInFuncionario(funcionariodto);

        var result = data.Result.Should().BeOfType<NotFoundObjectResult>();
        result.Subject.StatusCode.Should().Be(404);
    }

    [Fact]
    public void Post_LogInFuncionario_Unauthorized_Result()
    {
        var funcionariodto = new LoginFuncionarioDto
        {
            Login = "login",
            Senha = "senhaerrada"
        };

        var data = _controller.LogInFuncionario(funcionariodto);

        var result = data.Result.Should().BeOfType<UnauthorizedObjectResult>();
        result.Subject.StatusCode.Should().Be(401);
    }
}
