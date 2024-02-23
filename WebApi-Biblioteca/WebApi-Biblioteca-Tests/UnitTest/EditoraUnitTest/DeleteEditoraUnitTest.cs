using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Biblioteca.Controllers;

namespace WebApi_Biblioteca_Tests.UnitTest.EditoraUnitTest;

public class DeleteEditoraUnitTest : IClassFixture<EditoraUnitTestController>
{
    private readonly EditoraController _controller;

    public DeleteEditoraUnitTest(EditoraUnitTestController controller)
    {
        _controller = new EditoraController(controller.context, controller.mapper);
    }

    [Fact]
    public void DeleteEditora_Ok_Result()
    {
        var id = 7;

        var data = _controller.DeleteEditora(id);

        data.Should().BeOfType<OkObjectResult>().Which.StatusCode.Should().Be(200);
    }

    [Fact]
    public void DeleteEditora_NotFound_Result()
    {
        var id = 999;

        var data = _controller.DeleteEditora(id);

        data.Should().BeOfType<NotFoundObjectResult>().Which.StatusCode.Should().Be(404);
    }
}
