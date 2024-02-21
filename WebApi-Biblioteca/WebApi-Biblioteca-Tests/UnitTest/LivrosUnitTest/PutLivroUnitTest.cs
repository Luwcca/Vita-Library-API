using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Biblioteca.Controllers;
using WebApi_Biblioteca.Data.Dtos.LivrosDtos;

namespace WebApi_Biblioteca_Tests.UnitTest.LivrosUnitTest;

public class PutLivroUnitTest : IClassFixture<LivrosUnitTestController>
{
    private readonly LivroController _controller;

    public PutLivroUnitTest(LivrosUnitTestController controller)
    {
        _controller = new LivroController(controller.context, controller.mapper);
    }

    [Fact]
    public void PutLivro_Ok_Result()
    {
        var livroId = 44;

        var livrodto = new UpdateLivroDto
        {
            EditoraId = 2,
            Nome = "Livro",
            Assunto = "Programação",
            Tombo = 10239123,
            Status = true,
            Autor = "Livro"
        };

        var data = _controller.PutLivro(livroId, livrodto);

        var result = data.Result.Should().BeOfType<OkObjectResult>();
        result.Subject.StatusCode.Should().Be(200);
    }

    [Fact]
    public void PutLivro_NotFound_Result()
    {
        var livroId = 999;

        var livrodto = new UpdateLivroDto
        {
            EditoraId = 1,
            Nome = "Livro",
            Assunto = "Programação",
            Tombo = 10239123,
            Status = true,
            Autor = "Livro"
        };

        var data = _controller.PutLivro(livroId, livrodto);

        var result = data.Result.Should().BeOfType<NotFoundObjectResult>();
        result.Subject.StatusCode.Should().Be(404);
    }

    [Fact]
    public void PutLivro_BadRequest_Result()
    {
        var livroId = 44;

        var livrodto = new UpdateLivroDto
        {
            EditoraId = 1,
            Nome = "Livro",
            Tombo = 10239123,
            Status = true,
            Autor = "Livro"
        };

        var data = _controller.PutLivro(livroId, livrodto);

        var result = data.Result.Should().BeOfType<BadRequestObjectResult>();
        result.Subject.StatusCode.Should().Be(400);
    }

}
