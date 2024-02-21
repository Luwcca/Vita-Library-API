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

public class PutFuncionarioUnitTest : IClassFixture<FuncionarioUnitTestController>
{
    private readonly FuncionarioController _controller;

    public PutFuncionarioUnitTest(FuncionarioUnitTestController controller)
    {
        _controller = new FuncionarioController(controller.context, controller.mapper);
    }

    [Fact]
    public void PutFuncionario_Ok_Result()
    {
        var funcionarioid = 8;

        var funcionariodto = new UpdateFuncionarioDto
        {
            Nome = "Funcionario",
            CPF = 1234567891,
            Rua = "Rua",
            Bairro = "Bairro",
            Cidade = "Cidade",
            UF = "SP",
            Telefone = 1234151234,
            Login = "login3",
            Senha = "senha"
        };

        var data = _controller.PutFuncionario(funcionarioid, funcionariodto);

        var result = data.Result.Should().BeOfType<OkObjectResult>();
        result.Subject.StatusCode.Should().Be(200);
    }

    [Fact]
    public void PutFuncionario_NotFound_Result()
    {
        var funcionarioid = 999;

        var funcionariodto = new UpdateFuncionarioDto
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

        var data = _controller.PutFuncionario(funcionarioid, funcionariodto);

        var result = data.Result.Should().BeOfType<NotFoundObjectResult>();
        result.Subject.StatusCode.Should().Be(404);
    }

    [Fact]
    public void PutFuncionario_BadRequest_Result()
    {
        var funcionarioid = 8;

        var funcionariodto = new UpdateFuncionarioDto
        {
            Nome = "Funcionario",
            UF = "SP",
            Telefone = 1234151234,
            Login = "login2",
            Senha = "senha"
        };

        var data = _controller.PutFuncionario(funcionarioid, funcionariodto);

        var result = data.Result.Should().BeOfType<BadRequestObjectResult>();
        result.Subject.StatusCode.Should().Be(400);
    }
}
