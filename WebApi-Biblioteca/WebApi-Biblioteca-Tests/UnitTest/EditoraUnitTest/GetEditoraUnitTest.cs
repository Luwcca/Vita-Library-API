using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Biblioteca.Controllers;
using WebApi_Biblioteca.Data.Dtos.EditoraDtos;

namespace WebApi_Biblioteca_Tests.UnitTest.EditoraUnitTest;

public class GetEditoraUnitTest : IClassFixture<EditoraUnitTestController>
{
    private readonly EditoraController _controller;

    public GetEditoraUnitTest(EditoraUnitTestController controller)
    {
        _controller = new EditoraController(controller.context, controller.mapper);
    }

    [Fact]
    public void GetEditoraById_OK_Result()
    {
        var editoraId = 2;
        var data = _controller.GetEditoraByID(editoraId);

        data.Result.Should().BeOfType<OkObjectResult>()
             .Which.StatusCode.Should().Be(200);

    }

    [Fact]
    public void GetEditoraById_NotFound_Result()
    {
        var editoraId = 999;
        var data = _controller.GetEditoraByID(editoraId);

        data.Result.Should().BeOfType<NotFoundObjectResult>()
            .Which.StatusCode.Should().Be(404);


    }

    [Fact]
    public void GetEditoraById_BadRequest_Result()
    {
        var editoraId = 0;
        var data = _controller.GetEditoraByID(editoraId);

        data.Result.Should().BeOfType<BadRequestObjectResult>()
               .Which.StatusCode.Should().Be(400);

    }

    [Fact]
    public void GetEditora_EditoraDtoList_Result()
    {
        var data = _controller.GetEditora();

        data.Result.Should().BeOfType<OkObjectResult>()
             .Which.Value.Should().BeAssignableTo<IEnumerable<ReadEditoraDto>>();
    }
}
