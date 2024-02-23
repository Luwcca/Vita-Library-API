using FluentAssertions;
using FluentAssertions.Equivalency;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Controllers;
using WebApi_Biblioteca.Data.Dtos.AlunoDtos;

namespace WebApi_Biblioteca_Tests.UnitTest.AlunoUnitTest;

public class PostAlunoUnitTest : IClassFixture<AlunoUnitTestController>
{
    private readonly AlunoController _controller;

    public PostAlunoUnitTest(AlunoUnitTestController controller)
    {
        _controller = new AlunoController(controller.context, controller.mapper);
    }

    [Fact]
    public void PostAluno_CreatedAtAction_Result()
    {
        var alunodto = new CreateAlunoDto
        {
            Nome = "Aluno",
            Telefone = 1234567891,
            CPF = 1234567891,
            Rua = "Rua",
            Bairro = "Bairro",
            Cidade = "Cidade",
            UF = "SP",
            Multas = 0,
            Checkbox = true
        };

        var data = _controller.PostAluno(alunodto);

        var result = data.Result.Should().BeOfType<CreatedAtActionResult>();
        result.Subject.StatusCode.Should().Be(201);
    }



    [Fact]
    public void PostAluno_BadRequest_Result()
    {
        var alunodto = new CreateAlunoDto
        {
            Nome = "Aluno"
        };


        var data = _controller.PostAluno(alunodto);

        var result = data.Result.Should().BeOfType<BadRequestObjectResult>();
        result.Subject.StatusCode.Should().Be(400);
    }
}
