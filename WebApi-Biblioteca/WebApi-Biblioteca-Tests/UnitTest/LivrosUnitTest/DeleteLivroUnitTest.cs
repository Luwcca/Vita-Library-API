using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Biblioteca.Controllers;

namespace WebApi_Biblioteca_Tests.UnitTest.LivrosUnitTest;

public class DeleteLivroUnitTest : IClassFixture<LivrosUnitTestController>
{
    private readonly LivroController _controller;

    public DeleteLivroUnitTest(LivrosUnitTestController controller)
    {
        _controller = new LivroController(controller.context, controller.mapper);
    }

    [Fact]
    public void DeleteLivro_Ok_Result()
    {
        var id = 44;

        var data = _controller.DeleteLivro(id);

        data.Should().BeOfType<OkObjectResult>().Which.StatusCode.Should().Be(200);
    }

    [Fact]
    public void DeleteLivro_NotFound_Result()
    {
        var id = 999;

        var data = _controller.DeleteLivro(id);

        data.Should().BeOfType<NotFoundObjectResult>().Which.StatusCode.Should().Be(404);
    }
}
