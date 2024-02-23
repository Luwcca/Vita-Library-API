using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Controllers;
using WebApi_Biblioteca.Data.Dtos.AlunoDtos;

namespace WebApi_Biblioteca_Tests.UnitTest.AlunoUnitTest;

public class PutAlunoUnitTest : IClassFixture<AlunoUnitTestController>
{
    private readonly AlunoController _controller;

    public PutAlunoUnitTest(AlunoUnitTestController controller)
    {
        _controller = new AlunoController(controller.context, controller.mapper);
    }

    [Fact]
    public void PutAluno_Ok_Result()
    {
        var alunoid = 8;

        var alunodto = new UpdateAlunoDto
        {
            Nome = "Aluno",
            Telefone = 1234567891,
            CPF = 1234567891,
            Rua = "Rua",
            Bairro = "Bairro",
            Cidade = "Cidade",
            UF = "SP",
         
        };

        var data = _controller.PutAluno(alunoid, alunodto);

        var result = data.Result.Should().BeOfType<OkObjectResult>();
        result.Subject.StatusCode.Should().Be(200);
    }

    [Fact]
    public void PutLivro_NotFound_Result()
    {
        var alunoid = 999;

        var alunodto = new UpdateAlunoDto
        {
            Nome = "Aluno",
            Telefone = 1234567891,
            CPF = 1234567891,
            Rua = "Rua",
            Bairro = "Bairro",
            Cidade = "Cidade",
            UF = "SP",
         
        };

        var data = _controller.PutAluno(alunoid, alunodto);

        var result = data.Result.Should().BeOfType<NotFoundObjectResult>();
        result.Subject.StatusCode.Should().Be(404);
    }

    [Fact]
    public void PutLivro_BadRequest_Result()
    {
        var alunoid = 8;

        var alunodto = new UpdateAlunoDto
        {
            Telefone = 1234567891,
            CPF = 1234567891,
            Rua = "Rua",
            Bairro = "Bairro",
            Cidade = "Cidade",
            UF = "SP",

        };

        var data = _controller.PutAluno(alunoid, alunodto);

        var result = data.Result.Should().BeOfType<BadRequestObjectResult>();
        result.Subject.StatusCode.Should().Be(400);
    }
}
