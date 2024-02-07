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

    public void PostLivro_Ok_Result()
    {
        var livrodto = new CreateLivroDto
        {
            EditoraId = 1,
            Nome = "lIVRO",
            Assunto = "lIVRO",
            Tombo = 10239123,
            Status = true,
            Autor = "lIVRO"
        };

        var data = _controller.PostLivro(livrodto);

        var result = data.Result.Should().BeOfType<CreatedAtActionResult>();
        result.Subject.StatusCode.Should().Be(201);
    }
}
