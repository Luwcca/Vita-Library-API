using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Biblioteca.Controllers;
using WebApi_Biblioteca.Data.Dtos.EditoraDtos;
using WebApi_Biblioteca.Data.Dtos.LivrosDtos;

namespace WebApi_Biblioteca_Tests.UnitTest.EditoraUnitTest;

public class PutEditoraUnitTest : IClassFixture<EditoraUnitTestController>
{
    private readonly EditoraController _controller;

    public PutEditoraUnitTest(EditoraUnitTestController controller)
    {
        _controller = new EditoraController(controller.context, controller.mapper);
    }

    [Fact]
    public void PutEditora_Ok_Result()
    {
        var editoraid = 2;

        var editoradto = new UpdateEditoraDto
        {
            Nome = "Editora S.A",
            Endereco = "Rua",
            Bairro = "Bairro",
            Cidade = "Cidade",
            UF = "SP"
        };

        var data = _controller.PutEditora(editoraid, editoradto);

        var result = data.Result.Should().BeOfType<OkObjectResult>();
        result.Subject.StatusCode.Should().Be(200);
    }

    [Fact]
    public void PutEditora_NotFound_Result()
    {
        var editoraid = 999;

        var editoradto = new UpdateEditoraDto
        {
            Nome = "Editora S.A",
            Endereco = "Rua",
            Bairro = "Bairro",
            Cidade = "Cidade",
            UF = "SP"
        };

        var data = _controller.PutEditora(editoraid, editoradto);

        var result = data.Result.Should().BeOfType<NotFoundObjectResult>();
        result.Subject.StatusCode.Should().Be(404);
    }

    [Fact]
    public void PutEditora_BadRequest_Result()
    {
        var editoraid = 2;

        var editoradto = new UpdateEditoraDto
        {
            Nome = "Editora S.A",
            Bairro = "Bairro",
            Cidade = "Cidade",
            UF = "SP"
        };

        var data = _controller.PutEditora(editoraid, editoradto);

        var result = data.Result.Should().BeOfType<BadRequestObjectResult>();
        result.Subject.StatusCode.Should().Be(400);
    }
}
