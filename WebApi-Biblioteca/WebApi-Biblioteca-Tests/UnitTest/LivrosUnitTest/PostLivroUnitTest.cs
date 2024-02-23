using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Controllers;
using WebApi_Biblioteca.Data.Dtos.LivrosDtos;

namespace WebApi_Biblioteca_Tests.UnitTest.LivrosUnitTest;

public class PostLivroUnitTest : IClassFixture<LivrosUnitTestController>
{
    private readonly LivroController _controller;

    public PostLivroUnitTest(LivrosUnitTestController controller)
    {
        _controller = new LivroController(controller.context, controller.mapper);
    }

    [Fact]
    public void PostLivro_CreatedAtAction_Result()
    {
        var livrodto = new CreateLivroDto
        {
            EditoraId = 2,
            Nome = "Livro",
            Assunto = "Programação",
            Tombo = 10239123,
            Status = true,
            Autor = "Livro"
        };

        var data = _controller.PostLivro(livrodto);

        var result = data.Result.Should().BeOfType<CreatedAtActionResult>();
        result.Subject.StatusCode.Should().Be(201);
    }

    [Fact]
    public void PostLivro_BadRequest_Result()
    {
        var livrodto = new CreateLivroDto
        {
            EditoraId = 2,
            Nome = "Livro",
        };

        var data = _controller.PostLivro(livrodto);

        var result = data.Result.Should().BeOfType<BadRequestObjectResult>();
        result.Subject.StatusCode.Should().Be(400);
    }

    [Fact]
    public void PostLivro_NotFund_Result()
    {
        var livrodto = new CreateLivroDto
        {
            EditoraId = 999,
            Nome = "Livro",
            Assunto = "Programação",
            Tombo = 10239123,
            Status = true,
            Autor = "Livro"
        };

        var data = _controller.PostLivro(livrodto);

        var result = data.Result.Should().BeOfType<NotFoundObjectResult>();
        result.Subject.StatusCode.Should().Be(404);
    }
}
