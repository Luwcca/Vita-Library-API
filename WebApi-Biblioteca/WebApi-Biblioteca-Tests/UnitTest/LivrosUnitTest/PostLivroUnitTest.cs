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
    public void PostLivro_Ok_Result()
    {
        var livrodto = new CreateLivroDto
        {
            EditoraId = 1,
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
        CreateLivroDto livrodto = null;

        var data = _controller.PostLivro(livrodto);

        var result = data.Result.Should().BeOfType<BadRequestResult>();
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

        var result = data.Result.Should().BeOfType<NotFoundResult>();
        result.Subject.StatusCode.Should().Be(404);
    }
}
