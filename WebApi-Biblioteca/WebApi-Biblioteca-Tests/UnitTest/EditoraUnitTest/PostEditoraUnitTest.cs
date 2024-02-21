using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Controllers;
using WebApi_Biblioteca.Data.Dtos.EditoraDtos;

namespace WebApi_Biblioteca_Tests.UnitTest.EditoraUnitTest;

public class PostEditoraUnitTest : IClassFixture<EditoraUnitTestController>
{
    private readonly EditoraController _controller;

    public PostEditoraUnitTest(EditoraUnitTestController controller)
    {
        _controller = new EditoraController(controller.context, controller.mapper);
    }


    [Fact]
    public void PostEditora_CreatedAtAction_Result()
    {
        var editoradto = new CreateEditoraDto
        {
            Nome = "Editora S.A",
            Endereco = "Rua",
            Bairro = "Bairro",
            Cidade = "Cidade",
            UF = "SP"
        };

        var data = _controller.PostEditora(editoradto);

        var result = data.Result.Should().BeOfType<CreatedAtActionResult>();
        result.Subject.StatusCode.Should().Be(201);
    }



    [Fact]
    public void PostEditora_BadRequest_Result()
    {
        CreateEditoraDto editoradto = null;

        var data = _controller.PostEditora(editoradto);

        var result = data.Result.Should().BeOfType<BadRequestObjectResult>();
        result.Subject.StatusCode.Should().Be(400);
    }


}
